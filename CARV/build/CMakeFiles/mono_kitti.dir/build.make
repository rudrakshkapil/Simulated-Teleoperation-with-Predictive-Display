# CMAKE generated file: DO NOT EDIT!
# Generated by "Unix Makefiles" Generator, CMake Version 3.10

# Delete rule output on recipe failure.
.DELETE_ON_ERROR:


#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:


# Remove some rules from gmake that .SUFFIXES does not remove.
SUFFIXES =

.SUFFIXES: .hpux_make_needs_suffix_list


# Suppress display of executed commands.
$(VERBOSE).SILENT:


# A target that is always out of date.
cmake_force:

.PHONY : cmake_force

#=============================================================================
# Set environment variables for the build.

# The shell in which to execute make rules.
SHELL = /bin/sh

# The CMake executable.
CMAKE_COMMAND = /usr/bin/cmake

# The command to remove a file.
RM = /usr/bin/cmake -E remove -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = /home/hipstudents/Desktop/CARV_translation

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = /home/hipstudents/Desktop/CARV_translation/build

# Include any dependencies generated for this target.
include CMakeFiles/mono_kitti.dir/depend.make

# Include the progress variables for this target.
include CMakeFiles/mono_kitti.dir/progress.make

# Include the compile flags for this target's objects.
include CMakeFiles/mono_kitti.dir/flags.make

CMakeFiles/mono_kitti.dir/Examples/Monocular/mono_kitti.cc.o: CMakeFiles/mono_kitti.dir/flags.make
CMakeFiles/mono_kitti.dir/Examples/Monocular/mono_kitti.cc.o: ../Examples/Monocular/mono_kitti.cc
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/home/hipstudents/Desktop/CARV_translation/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object CMakeFiles/mono_kitti.dir/Examples/Monocular/mono_kitti.cc.o"
	/usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles/mono_kitti.dir/Examples/Monocular/mono_kitti.cc.o -c /home/hipstudents/Desktop/CARV_translation/Examples/Monocular/mono_kitti.cc

CMakeFiles/mono_kitti.dir/Examples/Monocular/mono_kitti.cc.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/mono_kitti.dir/Examples/Monocular/mono_kitti.cc.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /home/hipstudents/Desktop/CARV_translation/Examples/Monocular/mono_kitti.cc > CMakeFiles/mono_kitti.dir/Examples/Monocular/mono_kitti.cc.i

CMakeFiles/mono_kitti.dir/Examples/Monocular/mono_kitti.cc.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/mono_kitti.dir/Examples/Monocular/mono_kitti.cc.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /home/hipstudents/Desktop/CARV_translation/Examples/Monocular/mono_kitti.cc -o CMakeFiles/mono_kitti.dir/Examples/Monocular/mono_kitti.cc.s

CMakeFiles/mono_kitti.dir/Examples/Monocular/mono_kitti.cc.o.requires:

.PHONY : CMakeFiles/mono_kitti.dir/Examples/Monocular/mono_kitti.cc.o.requires

CMakeFiles/mono_kitti.dir/Examples/Monocular/mono_kitti.cc.o.provides: CMakeFiles/mono_kitti.dir/Examples/Monocular/mono_kitti.cc.o.requires
	$(MAKE) -f CMakeFiles/mono_kitti.dir/build.make CMakeFiles/mono_kitti.dir/Examples/Monocular/mono_kitti.cc.o.provides.build
.PHONY : CMakeFiles/mono_kitti.dir/Examples/Monocular/mono_kitti.cc.o.provides

CMakeFiles/mono_kitti.dir/Examples/Monocular/mono_kitti.cc.o.provides.build: CMakeFiles/mono_kitti.dir/Examples/Monocular/mono_kitti.cc.o


# Object files for target mono_kitti
mono_kitti_OBJECTS = \
"CMakeFiles/mono_kitti.dir/Examples/Monocular/mono_kitti.cc.o"

# External object files for target mono_kitti
mono_kitti_EXTERNAL_OBJECTS =

../Examples/Monocular/mono_kitti: CMakeFiles/mono_kitti.dir/Examples/Monocular/mono_kitti.cc.o
../Examples/Monocular/mono_kitti: CMakeFiles/mono_kitti.dir/build.make
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libmpfr.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libgmpxx.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libgmp.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libCGAL_Core.so.13.0.1
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libCGAL.so.13.0.1
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libboost_thread.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libboost_system.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libboost_chrono.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libboost_date_time.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libboost_atomic.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libpthread.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libboost_thread.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libboost_system.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libboost_chrono.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libboost_date_time.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libboost_atomic.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libpthread.so
../Examples/Monocular/mono_kitti: ../lib/libORB_SLAM2_Pub.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libmpfr.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libgmpxx.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libgmp.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libCGAL_Core.so.13.0.1
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libCGAL.so.13.0.1
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libboost_thread.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libboost_system.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libboost_chrono.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libboost_date_time.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libboost_atomic.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libpthread.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libboost_thread.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libboost_system.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libboost_chrono.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libboost_date_time.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libboost_atomic.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libpthread.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_shape.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_stitching.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_superres.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_videostab.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_aruco.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_bgsegm.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_bioinspired.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_ccalib.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_datasets.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_dpm.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_face.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_freetype.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_fuzzy.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_hdf.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_line_descriptor.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_optflow.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_video.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_plot.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_reg.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_saliency.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_stereo.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_structured_light.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_viz.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_phase_unwrapping.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_rgbd.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_surface_matching.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_text.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_ximgproc.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_calib3d.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_features2d.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_flann.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_xobjdetect.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_objdetect.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_ml.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_xphoto.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_highgui.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_photo.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_videoio.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_imgcodecs.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_imgproc.so.3.2.0
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libopencv_core.so.3.2.0
../Examples/Monocular/mono_kitti: /home/hipstudents/Desktop/Rudraksh/Pangolin-0.5/build/src/libpangolin.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libGL.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libGLU.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libGLEW.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libSM.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libICE.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libX11.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libXext.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libpython3.6m.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libdc1394.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libavcodec.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libavformat.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libavutil.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libswscale.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libpng.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libz.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libjpeg.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libtiff.so
../Examples/Monocular/mono_kitti: /usr/lib/x86_64-linux-gnu/libIlmImf.so
../Examples/Monocular/mono_kitti: ../Thirdparty/DBoW2/lib/libDBoW2.so
../Examples/Monocular/mono_kitti: ../Thirdparty/g2o/lib/libg2o.so
../Examples/Monocular/mono_kitti: ../Thirdparty/EDLines/EDLinesLib.a
../Examples/Monocular/mono_kitti: CMakeFiles/mono_kitti.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=/home/hipstudents/Desktop/CARV_translation/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Linking CXX executable ../Examples/Monocular/mono_kitti"
	$(CMAKE_COMMAND) -E cmake_link_script CMakeFiles/mono_kitti.dir/link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
CMakeFiles/mono_kitti.dir/build: ../Examples/Monocular/mono_kitti

.PHONY : CMakeFiles/mono_kitti.dir/build

CMakeFiles/mono_kitti.dir/requires: CMakeFiles/mono_kitti.dir/Examples/Monocular/mono_kitti.cc.o.requires

.PHONY : CMakeFiles/mono_kitti.dir/requires

CMakeFiles/mono_kitti.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles/mono_kitti.dir/cmake_clean.cmake
.PHONY : CMakeFiles/mono_kitti.dir/clean

CMakeFiles/mono_kitti.dir/depend:
	cd /home/hipstudents/Desktop/CARV_translation/build && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" /home/hipstudents/Desktop/CARV_translation /home/hipstudents/Desktop/CARV_translation /home/hipstudents/Desktop/CARV_translation/build /home/hipstudents/Desktop/CARV_translation/build /home/hipstudents/Desktop/CARV_translation/build/CMakeFiles/mono_kitti.dir/DependInfo.cmake --color=$(COLOR)
.PHONY : CMakeFiles/mono_kitti.dir/depend

