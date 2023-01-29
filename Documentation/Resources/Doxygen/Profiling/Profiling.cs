/*!
  \page PageProfiling Profiling
  \tableofcontents
  \section SectionProfNotes Notes
  \subsection SubsectionProfQuest2 Profiling on Quest 2
  - Locking CPU, GPU, FPS, and FOV allows for meaningful values to be obtained
  - OVR Metrics Tool used to obtain FPS, GPU%, and CPU%
  - App profiled as a deployed Android app and as a deployed WebGL app  
  
  \subsection SubsectionProfAndroid Profiling on Android
  - Stats obtained from OVR Profiler
  - Stats also obtained from editor profiler
    - draw calls per frame
    - Frame debugger
    - script debugging & profiling  
  
  \subsection SubsectionProfWebGL Profiling on WebGL
  - Stats obtained from OVR Profiler
  - Stats also obtained from Chrome DevTools
    - CPU time
    - GPU time
  
  
  \section SectionProfConclusions Conclusions
    - \ref PageProfilingEmptyScene
      - Android
        - CPU: ≈20%
        - GPU: 9%
      - WebGL
        - CPU: ≈30%
        - GPU: 22%  
      - In an empty scene, WebGL uses about 10% more GPU & CPU than Android.
    - \ref PageProfilingFillRate
      - Android: Filling the view resulted in a 25% increase in GPU usage (from 9% up to 35%); no increase in CPU usage (≈20%).
      - WebGL: Filling the view resulted in a 40% increase in GPU usage (from 22% up to 60%); no increase in CPU usage (≈40%).
      - General
        - GPU usage seems to drop linearly as the fill decreases.
    - \ref PageProfilingMSAA
      - Android: MSAA had a minor effect with x2 resulted in about 2% increase (from 20% up to 22%); MSAA x4 resulted in about 4% increase (from 20% up to 24%). Increasing MSAA seemed to have a minor effect on CPU usage (from 20% to 25%).
      - WebGL: MSAA had a major effect with x2 resulted in about 30% increase (from 60% to 75%); MSAA x4 resulted in about 60% increase (from 60% to 95%). Increasing MSAA seemed to have no effect on CPU usage.
    - \ref PageProfilingTerrain
      - General
        - The Tiny Terrain test demonstrates the terrain has minimal effect on GPU or CPU when it does not take up much of the screen.
        - Since the Tiny Terrain test had minimal effect, an increase in load is due to shader complexity.
        - The terrain took 50% more GPU than the simple quad.
  
      - Android
        - The terrain took 50% more GPU than the simple quad.
          - Half fill: from 20% to 33%
          - Full fill: from 35% to 50%
        - The CPU load did not change relative to the Empty Scene, regardless of how much of the terrain was displayed.  
      - WebGL
        - The terrain took 50% more GPU than the simple quad.
          - Half fill: from 40% to 60%
          - Full fill: from 60% to 90%
        - The CPU load did not change relative to how much of the terrain was displayed, but did generally increase the CPU load 25% (from 40% to 50%)  
	  
	  
*/
 
