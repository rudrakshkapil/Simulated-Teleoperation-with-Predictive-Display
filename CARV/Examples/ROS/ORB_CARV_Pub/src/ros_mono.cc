/**
* This file is part of ORB-SLAM2.
*
* Copyright (C) 2014-2016 Raúl Mur-Artal <raulmur at unizar dot es> (University of Zaragoza)
* For more information see <https://github.com/raulmur/ORB_SLAM2>
*
* ORB-SLAM2 is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* ORB-SLAM2 is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with ORB-SLAM2. If not, see <http://www.gnu.org/licenses/>.
*/


#include<iostream>
#include<algorithm>
#include<fstream>
#include<chrono>

#include<ros/ros.h>
#include <std_msgs/Header.h>
#include "std_msgs/String.h"
#include <image_transport/image_transport.h>
#include <cv_bridge/cv_bridge.h>
#include<opencv2/core/core.hpp>

#include"../../../include/System.h"

#include "../../../include/KeyFrame.h"
// #include "../../../include/MapPoint.h"
// #include "../../../include/Converter.h"
// #include "../../../include/Map.h"
// #include "../../../include/MapPoint.h"

using namespace std;



class ImageGrabber
{
public:
    ImageGrabber(ORB_SLAM2::System* pSLAM):mpSLAM(pSLAM){}

    void GrabImage(const sensor_msgs::ImageConstPtr& msg);

    ORB_SLAM2::System* mpSLAM;
};

// ADDED
class MoveGrabber
{
  public:
    MoveGrabber(ORB_SLAM2::System* pSLAM):mpSLAM(pSLAM){}

    void GrabMove(const std_msgs::String::ConstPtr& msg);

    ORB_SLAM2::System* mpSLAM;
};


int max_kfId;
ros::Publisher pubTask;
ros::Publisher pubCARVScripts;
int main(int argc, char **argv)
{
    max_kfId=0;

    ros::init(argc, argv, "Mono");
    ros::start();

    if(argc != 3)
    {
        cerr << endl << "Usage: rosrun ORB_SLAM2 Mono path_to_vocabulary path_to_settings" << endl;
        ros::shutdown();
        return 1;
    }

    // Create SLAM system. It initializes all system threads and gets ready to process frames.
    ORB_SLAM2::System SLAM(argv[1],argv[2],ORB_SLAM2::System::MONOCULAR,true);

    ImageGrabber igb(&SLAM);

    ros::NodeHandle nodeHandler;
    ros::Subscriber sub = nodeHandler.subscribe("/camera/image_raw", 1, &ImageGrabber::GrabImage, &igb);

    // ADDED: MoveGrabber object, new subscriber for that
    MoveGrabber mgb(&SLAM);
    ros::Subscriber sub_move = nodeHandler.subscribe("/moves/move_raw", 1, &MoveGrabber::GrabMove, &mgb);

    pubTask = nodeHandler.advertise<std_msgs::String>("/chris/twc", 1);
    pubCARVScripts = nodeHandler.advertise<std_msgs::String>("/carv/script", 1);
    ros::spin();

    // Stop all threads
    SLAM.Shutdown();

    // Save camera trajectory
    SLAM.SaveKeyFrameTrajectoryTUM("KeyFrameTrajectory.txt");

    ros::shutdown();

    return 0;
}

// ADDED:
void MoveGrabber::GrabMove(const std_msgs::String::ConstPtr& msg)
{
    std::cout << "hello \n";
    std::string str=(*msg).data;
    std::cout<<(*msg).data;
    int n=str.length();
    char ch[n+1];
    strcpy(ch, str.c_str());
    std::string st1=strtok(ch,"_");
    std::string st2=strtok(NULL,"_");
    std::string st3=strtok(NULL,"_");
    std::string sr00=strtok(NULL,"_");
    std::string sr01=strtok(NULL,"_");
    std::string sr02=strtok(NULL,"_");
    std::string sr10=strtok(NULL,"_");
    std::string sr11=strtok(NULL,"_");
    std::string sr12=strtok(NULL,"_");
    std::string sr20=strtok(NULL,"_");
    std::string sr21=strtok(NULL,"_");
    std::string sr22=strtok(NULL,"_");



    float ft1, ft2, ft3;
    ft1=std::stof(st3);
    ft2=std::stof(st2);
    ft3=std::stof(st1);
    //cv::Mat M=(cv::Mat_<float>(3,1) << f1,f2,f3);

    //std::cout << " Move Grabber: " << f1 <<" " << f2 << " " << f3 << endl;
    vector<float>M(3);
    M[0]=ft1 * -1;
    M[1]=ft2;
    M[2]=ft3;

    
    vector<float>R(9);
    R[0]=std::stof(sr00);
    R[1]=std::stof(sr01);
    R[2]=std::stof(sr02);
    R[3]=std::stof(sr10);
    R[4]=std::stof(sr11);
    R[5]=std::stof(sr12);
    R[6]=std::stof(sr20);
    R[7]=std::stof(sr21);
    R[8]=std::stof(sr22);

    for (int i = 0; i < 9; i++)
      std::cout << R[i] << ", ";
    
    mpSLAM->mpModeler->mpModelDrawer->settranslation(M);
    mpSLAM->mpModeler->mpModelDrawer->setrotation(R);

    

    // need to send updates to Model Drawer
}

void ImageGrabber::GrabImage(const sensor_msgs::ImageConstPtr& msg)
{
    // Copy the ros image message to cv::Mat.
    cv_bridge::CvImageConstPtr cv_ptr;
    try
    {
        cv_ptr = cv_bridge::toCvShare(msg);
    }
    catch (cv_bridge::Exception& e)
    {
        ROS_ERROR("cv_bridge exception: %s", e.what());
        return;
    }

    // TrackMonocular(im, timestamp)
    mpSLAM->TrackMonocular(cv_ptr->image,cv_ptr->header.stamp.toSec());
    ORB_SLAM2::KeyFrame* pKF = mpSLAM->mpMap->newestKeyFrame;;

    // mpSLAM (System *) -> mpMap (Map*) -> mpModeler (Modeler *) -> mpModelDrawer (ModelDrawer *) -> 
    // mpSLAM -> mpModelDrawer (ModelDrawer *) -> update attribute value from subscriber

    if(pKF != NULL)
    {
      int nowMaxId=mpSLAM->mpMap->GetMaxKFid();
      if(nowMaxId > max_kfId)
      {
        cv::Mat TWC = pKF->GetPoseInverse(); //return TWC

        // cout<<"key frame mnId: "<<pKF->mnId<<endl;//int--------------------------------------debug
        // cout.precision(15);
        // cout<<"key frame timestamp"<<std::fixed<<pKF->mTimeStamp<<endl;//double--------------------------------------debug
        // cout<<"ros mono MyCurrent Key Frame. camera center: "<<endl<<pKF->GetCameraCenter()<<endl;//--------------------------------debug

        std_msgs::String msg;
        std::stringstream ss;
        ss<<pKF->mnId<<",";
        ss<<std::setprecision(15)<<pKF->mTimeStamp<<",";
        for(int ti=0;ti<TWC.rows;ti++)
        {
          for(int tj=0;tj<TWC.cols;tj++)
          {
            std::ostringstream ssss;
            ssss << TWC.at<float>(ti,tj);
            ss<<ssss.str()<<",";
          }
        }
        msg.data = ss.str();
        pubTask.publish(msg);
        max_kfId=nowMaxId;
      }
    }
    std_msgs::String msgScript;  //publish CARV model scripts
    msgScript.data = mpSLAM->mpModeler->mTranscriptInterface.m_SFMTranscript.getNewCommand();
    if(msgScript.data !="")
      pubCARVScripts.publish(msgScript);
}



