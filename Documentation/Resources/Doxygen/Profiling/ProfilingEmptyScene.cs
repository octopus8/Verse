/*!
  \page PageProfilingEmptyScene Profiling Empty Scene
  \tableofcontents
    
  \section SectionProEmptySpecs Specifications
  - Empty scene with only the `Platform Rig` GameObject. No lights or anything.
  - CPU: Locked at Level 2
  - GPU: Locked at Level 2
  - FOV: Locked at Level 0
  - FPS: Max of 60
  - MSAA: off
	
  \section SectionProEmptyAndroid Android Results

  \subsection SectionProEmptyAndroidFrameDebug Frame Debugger
  - Only 3 draw calls; all clear calls (color+Z+stencil)  
  <a href="../Resources/Doxygen/Profiling/Resources/AndroidEmptySceneFrameDebug.png">
  <img src="../Resources/Doxygen/Profiling/Resources/AndroidEmptySceneFrameDebug.png" width=512px>
  </a>  
  <br/>
  - As displayed in the CPU Usage Profiler  
  <a href="../Resources/Doxygen/Profiling/Resources/AndroidEmptySceneFrameCPU.png">
  <img src="../Resources/Doxygen/Profiling/Resources/AndroidEmptySceneFrameCPU.png" width=512px>
  </a>
  <br/>
    
  \subsection SectionProEmptyAndroidOVRMT OVRMT
  - CPU: ≈20%
  - GPU: 9%
  <br/>
  <a href="../Resources/Doxygen/Profiling/Resources/AndroidEmptySceneOVRMT.jpg">
  <img src="../Resources/Doxygen/Profiling/Resources/AndroidEmptySceneOVRMT.jpg" width=256px>
  </a>
  
  
  \section SectionProEmptyBaseWebGL WebGL Results
  
  \subsection SectionProEmptyWebGLDevTools Chrome DevTools
  - CPU: ≈5.5ms
  <br/>
  <a href="../Resources/Doxygen/Profiling/Resources/WebGLEmptySceneDevToolsCPU.png">
  <img src="../Resources/Doxygen/Profiling/Resources/WebGLEmptySceneDevToolsCPU.png" width=512px>
  </a>  
  <br/>
  - GPU: ≈1.0ms
  <br/>
  <a href="../Resources/Doxygen/Profiling/Resources/WebGLEmptySceneDevToolsGPU.png">
  <img src="../Resources/Doxygen/Profiling/Resources/WebGLEmptySceneDevToolsGPU.png" width=512px>
  </a>  
  
  \subsection SectionProEmptyWebGLOVRMT OVRMT
  <b>OVRMT</b>
  - CPU: ≈30%
  - GPU: 22%
  <br/>
  <a href="../Resources/Doxygen/Profiling/Resources/WebGLEmptySceneOVRMT.jpg">
  <img src="../Resources/Doxygen/Profiling/Resources/WebGLEmptySceneOVRMT.jpg" width=256px>
  </a>

  \section SectionProEmptyBaseConclusions Conclusions
  - Android
    - CPU: ≈20%
    - GPU: 9%
  - WebGL
    - CPU: ≈30%
    - GPU: 22%  
  - Running an app as a WebGL app has about a 10% overhead on both the GPU & CPU than running the app as a standalone application.
  

*/
