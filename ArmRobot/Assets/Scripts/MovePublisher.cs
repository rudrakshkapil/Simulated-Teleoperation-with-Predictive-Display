using UnityEngine;
using System.Collections;

namespace RosSharp.RosBridgeClient
{
    public class MovePublisher : UnityPublisher<MessageTypes.Std.String>
    {
        private MessageTypes.Std.String message;
        public GameObject mainCamera;
        private Matrix4x4 oldCamMatrix;
        private Matrix4x4 sendCamMatrix;
        private bool firstFrame;

        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        private void Update()
        {
            UpdateMessage();
        }

        private void InitializeMessage()
        {
            message = new MessageTypes.Std.String();
            firstFrame = true;
        }

        private void UpdateMessage()
        {
            // get camera information
            


            Matrix4x4 camMatrix = mainCamera.GetComponent<Camera>().worldToCameraMatrix;
            if (firstFrame)
                oldCamMatrix = Matrix4x4.zero;

            sendCamMatrix[0, 3] = camMatrix[0, 3];// - oldCamMatrix[0, 3];
            sendCamMatrix[1, 3] = camMatrix[1, 3];// - oldCamMatrix[1, 3];
            sendCamMatrix[2, 3] = camMatrix[2, 3];// - oldCamMatrix[2, 3];

            message.data = camMatrix[0, 3].ToString() + "_" + camMatrix[1, 3].ToString() + "_" + camMatrix[2, 3].ToString() + "_";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    message.data += camMatrix[i, j].ToString() + "_";
                }
            }

            //message.data += sendCamMatrix[0, 0].ToString() + "_" + sendCamMatrix[0, 1].ToString() + "_"
            //Debug.Log(message.data);
            Publish(message);

            firstFrame = false;
            oldCamMatrix = camMatrix;
        }

    }
}