/*!
  \page PageProfilingTerrain Profiling Terrain
  \tableofcontents

  \section SectionProTerrainTiny Tiny Test
  \subsection SubsectionProTerrainTinyFrameDesc Description
  In this test, the terrain is made small and at a distance. This tests rendering the whole terrain, but minimizes fillrate.
  
  \subsection SubsectionProTerrainTinyFrameDebugger Frame Debugger 
  <br/>
  <a href="../Resources/Doxygen/Profiling/Resources/TerrainTinyFrameDebugger.png">
  <img src="../Resources/Doxygen/Profiling/Resources/TerrainTinyFrameDebugger.png" width=256px>
  </a>  

  \subsection SubsectionProTerrainTinyAndroid Android OVRMT Results
  - CPU: ≈20%
  - GPU: 9%
  <br/>
  <a href="../Resources/Doxygen/Profiling/Resources/TerrainTinyAndroid.jpg">
  <img src="../Resources/Doxygen/Profiling/Resources/TerrainTinyAndroid.jpg" width=256px>
  </a>  

  \subsection SubsectionProTerrainTinyWebGL WebGL OVRMT Results
  - CPU: ≈20%
  - GPU: 9%
  <br/>
  <a href="../Resources/Doxygen/Profiling/Resources/TerrainTinyWebGL.jpg">
  <img src="../Resources/Doxygen/Profiling/Resources/TerrainTinyWebGL.jpg" width=256px>
  </a>  

  \section SectionProTerrainHalf Half-Filled View
  \subsection SubsectionProTerrainHalfDesc Description
  In this test, the terrain is at normal scale and the view is as if the user was standing on the terrain and looking straight forward. This tests rendering the terrain such that it fills about half the view. This could be considered nominal behaviour.  

  \subsection SubsectionProTerrainHalfFrameDebugger Frame Debugger 
  <br/>
  <a href="../Resources/Doxygen/Profiling/Resources/TerrainHalfFrameDebugger.png">
  <img src="../Resources/Doxygen/Profiling/Resources/TerrainHalfFrameDebugger.png" width=256px>
  </a>  

  \subsection SubsectionProTerrainHalfAndroid Android OVRMT Results
  - CPU: ≈20%
  - GPU: 9%
  <br/>
  <a href="../Resources/Doxygen/Profiling/Resources/TerrainHalfAndroid.jpg">
  <img src="../Resources/Doxygen/Profiling/Resources/TerrainHalfAndroid.jpg" width=256px>
  </a>  

  \subsection SubsectionProTerrainHalfWebGL WebGL OVRMT Results
  - CPU: ≈20%
  - GPU: 9%
  <br/>
  <a href="../Resources/Doxygen/Profiling/Resources/TerrainHalfWebGL.jpg">
  <img src="../Resources/Doxygen/Profiling/Resources/TerrainHalfWebGL.jpg" width=256px>
  </a>  
  
  
  \section SectionProTerrainFull Filled View
  \subsection SubsectionProTerrainFullDesc Description

  \subsection SubsectionProTerrainFullFrameDebugger Frame Debugger 
  <br/>
  <a href="../Resources/Doxygen/Profiling/Resources/TerrainFullFrameDebugger.png">
  <img src="../Resources/Doxygen/Profiling/Resources/TerrainFullFrameDebugger.png" width=256px>
  </a>  

  \subsection SubsectionProTerrainFullAndroid Android OVRMT Results
  - CPU: ≈20%
  - GPU: ≈50%
  <br/>
  <a href="../Resources/Doxygen/Profiling/Resources/TerrainFullAndroid.jpg">
  <img src="../Resources/Doxygen/Profiling/Resources/TerrainFullAndroid.jpg" width=256px>
  </a>  

  \subsection SubsectionProTerrainFullWebGL WebGL OVRMT Results
  - CPU: ≈50%
  - GPU: ≈90%
  <br/>
  <a href="../Resources/Doxygen/Profiling/Resources/TerrainFullWebGL.jpg">
  <img src="../Resources/Doxygen/Profiling/Resources/TerrainFullWebGL.jpg" width=256px>
  </a>  
  
  \section SectionProTerrainConclusions Conclusions
  \subsection SubsectionProTerrainConclusionsGeneral General
  - The Tiny Terrain test demonstrates the terrain has minimal effect on GPU or CPU when it does not take up much of the screen.
  - Since the Tiny Terrain test had minimal effect, an increase in load is due to shader complexity.
  - The terrain took 50% more GPU than the simple quad.
  
  \subsection SubsectionProTerrainConclusionsAndroid Android
  - The terrain took 50% more GPU than the simple quad.
    - Half fill: from 20% to 33%
    - Full fill: from 35% to 50%
  - The CPU load did not change relative to the Empty Scene, regardless of how much of the terrain was displayed.
  
  \subsection SubsectionProTerrainConclusionsWebGL WebGL
  - The terrain took 50% more GPU than the simple quad.
    - Half fill: from 40% to 60%
    - Full fill: from 60% to 90%
  - The CPU load did not change relative to how much of the terrain was displayed, but did generally increase the CPU load 25% (from 40% to 50%)  

*/
