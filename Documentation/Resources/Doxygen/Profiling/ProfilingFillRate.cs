/*!
  \page PageProfilingFillRate Profiling Fill Rate
  \tableofcontents

  \section SectionProFillDesc Scene Description
  The scene contains the `Platform Rig` and a single static lightmapped & textured quad that sits in front of the camera such that when looking straight forward it takes up the full view. If the user looks up a certain amount, the view can be changed such that the quad takes up only the bottom half of the view. Looking away from the quad results in an empty view. A color is used to clear the view.

  \section SectionProFillSpecs Specifications
  - CPU: Locked at Level 2
  - GPU: Locked at Level 2
  - FOV: Locked at Level 0
  - FPS: Max of 60
  - MSAA: off

  \section SectionProFillFrameDebugger Frame Debugger
  - 1 draw call
  <br/>
  <a href="../Resources/Doxygen/Profiling/Resources/AndroidFillFrameDebug.png">
  <img src="../Resources/Doxygen/Profiling/Resources/AndroidFillFrameDebug.png" width=512px>
  </a>  
  
   
  \section SectionProFillAndroid Android Results
  \subsection SubsectionProFillAndroidFilled OVRMT Filled View
  - CPU: ≈20%
  - GPU: ≈35%
  <br/>
  <a href="../Resources/Doxygen/Profiling/Resources/AndroidFillFullOVRMT.jpg">
  <img src="../Resources/Doxygen/Profiling/Resources/AndroidFillFullOVRMT.jpg" width=256px>
  </a>  

  \subsection SubsectionProFillAndroidHalfFilled OVRMT Half-Filled View
  - CPU: ≈20%
  - GPU: ≈20%
  <br/>
  <a href="../Resources/Doxygen/Profiling/Resources/AndroidFillHalfOVRMT.jpg">
  <img src="../Resources/Doxygen/Profiling/Resources/AndroidFillHalfOVRMT.jpg" width=256px>
  </a>  

  \section SectionProFillWebGL WebGL Results
  \subsection SubsectionProFillWebGLFilled OVRMT Filled View
  - CPU: ≈40%
  - GPU: ≈60%
  <br/>
  <a href="../Resources/Doxygen/Profiling/Resources/WebGLFillFullOVRMT.jpg">
  <img src="../Resources/Doxygen/Profiling/Resources/WebGLFillFullOVRMT.jpg" width=256px>
  </a>  
  
  \subsection SubsectionProFillWebGLHalfFilled OVRMT Half-Filled View
  - CPU: ≈40%
  - GPU: ≈40%
  <br/>
  <a href="../Resources/Doxygen/Profiling/Resources/WebGLFillHalfOVRMT.jpg">
  <img src="../Resources/Doxygen/Profiling/Resources/WebGLFillHalfOVRMT.jpg" width=256px>
  </a>  

  \section SubsectionProFillConclusions Conclusions
  - Android: Filling the view resulted in a 25% increase in GPU usage (from 9% up to 35%); no increase in CPU usage (≈20%).
  - WebGL: Filling the view resulted in a 40% increase in GPU usage (from 22% up to 60%); no increase in CPU usage (≈40%).
  - General
    - GPU usage seems to drop linearly as the fill decreases.
  

*/
