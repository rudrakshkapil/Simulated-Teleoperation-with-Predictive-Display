# Simulated Robotic Arm Teleoperation using Predictive Display
This is our project's code repository for the CMPUT 615 3D Computer Vision course during the Winter '22 term.

Group members:
- Rudraksh Kapil (rkapil@ualberta.ca)
- Raghav Madan (rmadan2@ualberta.ca)


## Code Arrangment and Explanation
The root directory contains two folders. `/ArmRobot` contains the Unity code and game scene. The game scene can be found in `/ArmRobot/Assets/Scenes/Office.unity`. This scene has several game objects, such as the robot arm, the objects it interacts with, other scene objects, and objects that handle ROS communication. Changes to the scene can be made using a Unity editor (see pre-requisites). Changes to the C# scripts that the game objects rely can be made on using Visual Studio.

`/CARV` contains the online 3D reconstruction and predictive display implementations. The underlying 3D reconstruction framework is the same as in the [original CARV repository](https://github.com/atlas-jj/ORB-SLAM-free-space-carving), with our predictive display algorithm being implementated in the `/CARV/Modeler` source and header files. The ROS communication is implemented in `/CARV/Examples/ROS/ORB_CARV_Pub/ros_mono.cc`.



## Pre-requisites
#### Operating System


## Build Instructions



## Run Instructions




