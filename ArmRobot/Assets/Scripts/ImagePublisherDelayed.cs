/*
© CentraleSupelec, 2017
Author: Dr. Jeremy Fix (jeremy.fix@centralesupelec.fr)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
<http://www.apache.org/licenses/LICENSE-2.0>.
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

// Adjustments to new Publication Timing and Execution Framework 
// © Siemens AG, 2018, Dr. Martin Bischoff (martin.bischoff@siemens.com)

using UnityEngine;
using System.Collections.Generic;

namespace RosSharp.RosBridgeClient
{
    public class ImagePublisherDelayed : UnityPublisher<MessageTypes.Sensor.CompressedImage>
    {
        public Camera ImageCamera;
        public string FrameId = "Camera";
        public static int resolutionWidth = 640;
        public static int resolutionHeight = 480;
        [Range(0, 100)]
        public int qualityLevel = 50;

        private MessageTypes.Sensor.CompressedImage message;
        //private Texture2D texture2D;
        //private Rect rect;


        // for sending in spurts
        public bool reconstructionDone = false;
        private int framesCounter;
        private int framesToSkip;



        private void Awake()
        {
            frames = new Frame[bufferSize];

            // Change the depth value from 24 to 16 may improve performances. And try to specify an image format with better compression.
            renderTexture = new RenderTexture(resolutionWidth,resolutionHeight, 24);
            ImageCamera.targetTexture = renderTexture;
            StartCoroutine(Render());
        }

        protected override void Start()
        {
            base.Start();
            InitializeGameObject();
            InitializeMessage();

            framesToSkip = (int)(delay * 30);

            //Camera.onPostRender += UpdateImage;
            StartCoroutine(Render());

        }

        /// <summary>
        /// Makes the camera render with a delay
        /// </summary>
        /// <returns></returns>
        private IEnumerator<WaitForEndOfFrame> Render()
        {
            WaitForEndOfFrame wait = new WaitForEndOfFrame();
            //WaitForSeconds waitDelayed = new WaitForSeconds(delay);


            while (true)
            {
                yield return wait;

                capturedFrameIndex = frameIndex % bufferSize;

                frames[capturedFrameIndex].CaptureFrom(renderTexture);

                // Find the index of the frame to render
                // The foor loop is **voluntary** empty
                for (; frames[renderedFrameIndex].CapturedBefore(Time.time - delay); renderedFrameIndex = (renderedFrameIndex + 1) % bufferSize) ;


                // skip the necessary frames
                if (reconstructionDone)
                {
                    if (framesCounter > 0)
                    {
                        framesCounter -= 1;
                        frameIndex++;       // not for skipping
                        continue;
                    }
                    else
                        framesCounter = framesToSkip;
                }



                // send message and render frame
                UpdateMessage(frames[renderedFrameIndex].texture);
                Graphics.Blit(frames[renderedFrameIndex], null as RenderTexture);
                frameIndex++;
            }
        }

        // private void UpdateImage(Camera _camera)
        // {
        //     if (texture2D != null && _camera == this.ImageCamera)
        //         UpdateMessage();
        // }

        private void InitializeGameObject()
        {
            //texture2D = new Texture2D(resolutionWidth, resolutionHeight, TextureFormat.RGB24, false);
            //rect = new Rect(0, 0, resolutionWidth, resolutionHeight);
            //ImageCamera.targetTexture = new RenderTexture(resolutionWidth, resolutionHeight, 24);
        }

        private void InitializeMessage()
        {
            message = new MessageTypes.Sensor.CompressedImage();
            message.header.frame_id = FrameId;
            message.format = "jpeg";
        }

        private void UpdateMessage(Texture2D texture2D)
        {



            message.header.Update();
            //texture2D.ReadPixels(rect, 0, 0);
            message.data = texture2D.EncodeToJPG(qualityLevel);
            Publish(message);
        }


        public struct Frame
        {
            /// <summary>
            /// The texture representing the frame
            /// </summary>
            public Texture2D texture;

            /// <summary>
            /// The time (in seconds) the frame has been captured at
            /// </summary>
            private float recordedTime;

            /// <summary>
            /// Captures a new frame using the given render texture
            /// </summary>
            /// <param name="renderTexture">The render texture this frame must be captured from</param>
            public void CaptureFrom(RenderTexture renderTexture)
            {
                RenderTexture.active = renderTexture;

                // Create a new texture if none have been created yet in the given array index
                if (texture == null)
                    texture = new Texture2D(resolutionWidth, resolutionHeight, TextureFormat.RGB24, false);

                // Save what the camera sees into the texture
                texture.ReadPixels(new Rect(0, 0, resolutionWidth, resolutionHeight), 0, 0);
                texture.Apply();

                recordedTime = Time.time;

                RenderTexture.active = null;
            }

            /// <summary>
            /// Indicates whether the frame has been captured before the given time
            /// </summary>
            /// <param name="time">The time</param>
            /// <returns><c>true</c> if the frame has been captured before the given time, <c>false</c> otherwise</returns>
            public bool CapturedBefore(float time)
            {
                return recordedTime < time;
            }

            /// <summary>
            /// Operator to convert the frame to a texture
            /// </summary>
            /// <param name="frame"></param>
            public static implicit operator Texture2D(Frame frame) { return frame.texture; }
        }


        /// <summary>
        /// The delay
        /// </summary>
        [SerializeField]
        public float delay = 0.5f;

        /// <summary>
        /// The size of the buffer containing the recorded images
        /// </summary>
        /// <remarks>
        /// Try to keep this value as low as possible according to the delay
        /// </remarks>
        private int bufferSize = 512;

        /// <summary>
        /// The render texture used to record what the camera sees
        /// </summary>
        private RenderTexture renderTexture;

        /// <summary>
        /// The recorded frames
        /// </summary>
        private Frame[] frames;

        /// <summary>
        /// The index of the captured texture
        /// </summary>
        private int capturedFrameIndex;

        /// <summary>
        /// The index of the rendered texture
        /// </summary>
        private int renderedFrameIndex;

        /// <summary>
        /// The frame index
        /// </summary>
        private int frameIndex;


    }
}
