# Project Title: ML 23/24-04 Implement the Spatial Pooler SDR Reconstruction
[![Made with - C#](https://img.shields.io/badge/Made_with-C%23-2ea44f?style=for-the-badge&logo=C%23)](https://learn.microsoft.com/en-us/dotnet/csharp/)
![Built With - ❤️](https://img.shields.io/badge/Built_With-❤️-2ea44f?style=for-the-badge&logo=Love)
### An experiment to demonstrate how the reconstruction method recreates the images and texts learnt by the Spatial Pooler method using C#.
## Overview
* [Contributors](#Contributers)
* [Problem Statement](#Problem-Statement)
* [Sparse Distributed Representation(SDR)](#Sparse-Distributed-Representation-(SDR))
* [Hierarchical temporal memory (HTM)](#Hierarchical-temporal-memory-(HTM))
* [Reconstructing the SP algorithm](#Reconstructing-the-SP-algorithm)

## Contributers:
This project is created by the joint efforts of
* [Subham Singh](https://github.com/Subham2901)
* [Amit Maity](https://github.com/Neel1097)
* [Rubi Kiran](https://github.com/RubiKirann)

 ## Problem Statement: 
 Spatial Pooler converts the input into the SDR. The new version of the neocortexapi provides a method Reconstruct (), which performs the inverse function of the SP. It reconstructs the input from the input. Your task is to create an experiment which demonstrates how the reconstruction works. The experiment will first learn the spatial input (both numbers and images), and then, after the SP has entered the stable state, it will start the reconstruction of all learned patterns.
The experiment should show visually and mathematically the difference between the input and reconstructed pattern.
Visualize result. Provide multiple experiments using numerical (use scalarencoder) and image inputs (use binarizer).
Represent the difference between input and output mathematically.
Ref: Method Reconstruct in SpatialPooler.cs.

 ## Sparse Distributed Representation(SDR):
According to recent findings in neuroscience, the brain processes information using Sparse Distributed Representations. This is true for all mammals, from mice to humans. These SDRs are the key to a better understanding of the brain’s computational approach. SDRs visualize the information processed by the brain at a given moment, each active cell bearing some semantic aspect of the overall message. 
Sparse means that only a few of the many (thousands of) neurons are active at the same time, in contrast to the typical “dense” representation, in computers, of a few bits of 0s and 1s. Distributed means that not only are the active cells spread across the representation, but the significance of the pattern is too. This makes the SDR resilient to the failure of single neurons and allows sub-sampling. As each bit or neuron has a meaning, if the same bit is active in two SDRs, it means that they are semantically similar: that is the key to our computational approach. (Source:https://www.cortical.io/science/sparse-distributed-representations/?highlight=SDR )

 ## Hierarchical temporal memory (HTM):

Hierarchical temporal memory (HTM) provides a theoretical framework that models several key computational principles of the neocortex. This paper analyzes an important component of HTM, the HTM spatial pooler (SP). The HTM spatial pooler represents a neurally inspired learning algorithm for creating sparse representations from noisy data streams in an online fashion. It models how neurons learn feedforward connections and form efficient representations of the input. It converts arbitrary binary input patterns into sparse distributed representations (SDRs) using a combination of competitive Hebbian learning rules and homeostatic excitability control. (Source: https://www.numenta.com/resources/research-publications/papers/htm-spatial-pooler-neocortical-algorithm-for-online-sparse-distributed-coding/)

![spatialpooler](https://github.com/Neel1097/Team-ByteBaite_neocortexapi/assets/60136654/b8b2db0b-3935-46cc-a203-5a3b6c22e68d)

 ## Reconstructing the SP algorithm:
  To “Reconstruct the SP algorithm” you could use the information of the connected synapses lying in the SP data structure. The first step would be to get the synapses with the function getConnectedSynapses.

Here is an example from the NuPIC Github repo:

![Capture](https://github.com/Neel1097/Team-ByteBaite_neocortexapi/assets/60136654/642e46ce-1018-4ea3-a278-2854aca7af32)



