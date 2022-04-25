# Simulated Robotic Arm Teleoperation using Predictive Display
This is our project's code repository for the CMPUT 615 3D Computer Vision course during the Winter '22 term.

Group members:
- Rudraksh Kapil (rkapil@ualberta.ca)
- Raghav Madan (rmadan2@ualberta.ca)





## Pre-requisites
Getting this project to build and run properly can be tricky as it needs very specific versions of the different required software. The information in this section should be descriptive enough to guide you through the process correctly, but if you face any issues feel free to reach out to either of us.

#### Operating System
We recommend using Ubuntu 18.04.3 LTS.

#### Unity Editor
Unity projects should be opened with the editor version they were created with. Otherwise the project would need to be upgraded and may cause minor issues. Therefore we recommend version 2020.3.32f1.

#### ROS




## Build Instructions



## Run Instructions



## Code Arrangment and Explanation
The root directory contains two folders. `/ArmRobot` contains the Unity code and game scene. The game scene can be found in `/ArmRobot/Assets/Scenes/Office.unity`. This scene has several game objects, such as the robot arm, the objects it interacts with, other scene objects, and objects that handle ROS communication. Changes to the scene can be made using a Unity editor (see pre-requisites). Changes to the C# scripts that the game objects rely can be made on using Visual Studio.

`/CARV` contains the online 3D reconstruction and predictive display implementations. The underlying 3D reconstruction framework is the same as in the [original CARV repository](https://github.com/atlas-jj/ORB-SLAM-free-space-carving), with our predictive display algorithm being implementated in the `/CARV/Modeler` source and header files. The ROS communication is implemented in `/CARV/Examples/ROS/ORB_CARV_Pub/ros_mono.cc`.





