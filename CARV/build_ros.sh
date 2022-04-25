#!/usr/bin/env bash
echo "Building ROS nodes"


cd Examples/ROS/ORB_CARV_Pub
rm -rf build
mkdir build
cd build
cmake .. -DROS_BUILD_TYPE=Debug 
make clean
make -j16
