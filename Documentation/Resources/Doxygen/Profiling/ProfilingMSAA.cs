/*!
  \page PageProfilingMSAA Profiling MSAA
  \tableofcontents

  \section SectionProMSAAAndroid Android Results
  \subsection SubsectionProMSAA2xAndroid OVRMT MSAA 2x
  - CPU: ≈22%
  - GPU: ≈40%
  <br/>
  <a href="../Resources/Doxygen/Profiling/Resources/AndroidMSAA2xOVRMT.jpg">
  <img src="../Resources/Doxygen/Profiling/Resources/AndroidMSAA2xOVRMT.jpg" width=256px>
  </a>  

  \subsection SubsectionProMSAA4xAndroid OVRMT MSAA 4x
  - CPU: ≈25%
  - GPU: ≈45%
  <br/>
  <a href="../Resources/Doxygen/Profiling/Resources/AndroidMSAA4xOVRMT.jpg">
  <img src="../Resources/Doxygen/Profiling/Resources/AndroidMSAA4xOVRMT.jpg" width=256px>
  </a>  

  \section SectionProMSAAWebGL WebGL Results
  \subsection SubsectionProMSAA2xWebGL OVRMT MSAA 2x
  - CPU: ≈40%
  - GPU: ≈75%
  <br/>
  <a href="../Resources/Doxygen/Profiling/Resources/WebGLMSAA2xOVRMT.jpg">
  <img src="../Resources/Doxygen/Profiling/Resources/WebGLMSAA2xOVRMT.jpg" width=256px>
  </a>  

  \subsection SubsectionProMSAA4xWebGL OVRMT MSAA 4x
  - CPU: ≈40%
  - GPU: ≈95%
  <br/>
  <a href="../Resources/Doxygen/Profiling/Resources/WebGLMSAA4xOVRMT.jpg">
  <img src="../Resources/Doxygen/Profiling/Resources/WebGLMSAA4xOVRMT.jpg" width=256px>
  </a>  

  \section SectionProMSAAConclusions Conclusions
  - Android: MSAA had a minor effect with x2 resulted in about 2% increase (from 20% up to 22%); MSAA x4 resulted in about 4% increase (from 20% up to 24%). Increasing MSAA seemed to have a minor effect on CPU usage (from 20% to 25%).
  - WebGL: MSAA had a major effect with x2 resulted in about 30% increase (from 60% to 75%); MSAA x4 resulted in about 60% increase (from 60% to 95%). Increasing MSAA seemed to have no effect on CPU usage.
  



*/
