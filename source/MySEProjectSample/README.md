# Project Title: ML 23/24-04 Implement the Spatial Pooler SDR Reconstruction
[![Made with - C#](https://img.shields.io/badge/Made_with-C%23-2ea44f?style=for-the-badge&logo=C%23)](https://learn.microsoft.com/en-us/dotnet/csharp/)
![Built With - ❤️](https://img.shields.io/badge/Built_With-❤️-2ea44f?style=for-the-badge&logo=Love)

### An experiment to demonstrate how the reconstruction method recreates the images and texts learnt by the Spatial Pooler method using C#.
## Overview
* [Contributors](#Contributers)
* [Problem Statement](#Problem-Statement)
* [Introduction](#Introduction)
* [Sparse Distributed Representation](#Sparse-Distributed-Representation)
* [Hierarchical temporal memory](#Hierarchical-temporal-memory)
* [HTM Encoder](#HTM-Encoder)
* [The Encoding Process](#The-Encoding-Process)
* [Reconstructing the SP algorithm](#Reconstructing-the-SP-algorithm)
* [Phases of SP](#Phases-of-SP)
  
## Contributers:

This project is created by the joint efforts of
* [Subham Singh](https://github.com/Subham2901)
* [Amit Maity](https://github.com/Neel1097)
* [Rubi Kiran](https://github.com/RubiKirann)


 ## Problem Statement: 
 Spatial Pooler converts the input into the SDR. The new version of the neocortexapi provides a method Reconstruct (), which performs the inverse function of the SP. It reconstructs the input from the input. Your task is to create an experiment that shows how the reconstruction works. The experiment will first learn the spatial input (both numbers and images), and then, after the SP has entered the stable state, it will start the reconstruction of all learned patterns.
The experiment should show visually and mathematically the difference between the input and reconstructed pattern.
Visualize result. Provide multiple experiments using numerical (use scalar encoder) and image inputs (use binarizer).
Represent the difference between input and output mathematically.
Ref: Method Reconstruct in SpatialPooler.cs.
 ## Introduction:
 
 In this project, an experiment is performed that makes us indulge with the knowledge of spatial pooler,an integral component in the neocortexapi. The Spatial Pooler plays a pivotal role in converting input into Sparse Distributed Representations (SDRs), the newly updated version of the neocortexapi provided us with a highly efficient working model of a method called as reconstruct(), which is capable to perform the inverse fuction of the spatial pooler.
The ultimate goal of this experiment is to reconstruct the input provided to the spatial pooler through scalar encoders for numerical inputs and image binarizer for pictorial data. The entire experiment is performed in two sections, initially a scalar encoder or image binariser is used to feed into the spatial pooler such that it can produce the SDR and reach a stable state and once the program reaches a stable state and the initiation of the next section begins, where the output from the Spatial Pooler fucntion is fed into the reconstruct method to verify and test the accuracy of the reconstruct method.
 The final step of the experiment is to draw comparissions by using different metirces which can compare the similarity of the numbers or the images that was fed into the encoders with the final output received from the reconstruct() method.

  **[Go to top &uarr;](#Overview)**
 ## Sparse Distributed Representation:

According to recent findings in neuroscience, the brain processes information using Sparse Distributed Representations. This is true for all mammals, from mice to humans. These SDRs are the key to a better understanding of the brain’s computational approach. SDRs visualize the information processed by the brain at a given moment, each active cell bearing some semantic aspect of the overall message. 
Sparse means that only a few of the many (thousands of) neurons are active simultaneously, in contrast to the typical “dense” representation, in computers, of a few bits of 0s and 1s. Distributed means that not only are the active cells spread across the representation, but the significance of the pattern is too. This makes the SDR resilient to the failure of single neurons and allows sub-sampling. As each bit or neuron has a meaning, if the same bit is active in two SDRs, it means that they are semantically similar: that is the key to our computational approach. (Source:https://www.cortical.io/science/sparse-distributed-representations/?highlight=SDR )

 ## Hierarchical temporal memory:

Hierarchical temporal memory (HTM) provides a theoretical framework that models several key computational principles of the neocortex. This paper analyzes an important component of HTM, the HTM spatial pooler (SP). The HTM spatial pooler represents a neurally inspired learning algorithm for creating sparse representations from noisy data streams in an online fashion. It models how neurons learn feedforward connections and form efficient representations of the input. It converts arbitrary binary input patterns into sparse distributed representations (SDRs) using competitive Hebbian learning rules and homeostatic excitability control. (Source: https://www.numenta.com/resources/research-publications/papers/htm-spatial-pooler-neocortical-algorithm-for-online-sparse-distributed-coding/)
![spatialpooler](https://github.com/Neel1097/Team-ByteBaite_neocortexapi/assets/60136654/b8b2db0b-3935-46cc-a203-5a3b6c22e68d)

 **[Go to top &uarr;](#Overview)**
## HTM Encoder:

Hierarchical Temporal Memory (HTM) provides a flexible and biologically accurate framework for solving prediction, classification, and anomaly detection problems for a broad range of data types. HTM systems require data input in the form of Sparse Distributed Representations (SDRs). SDRs are quite different from standard computer representations, such as ASCII for text, in that meaning is encoded directly into the representation. An SDR consists of a large array of bits of which most are zeros and a few are ones. Each bit carries some semantic meaning that if two SDRs have more than a few overlapping one-bits, then those two SDRs have similar meanings. Any data that can be converted into an SDR can be used in a wide range of applications using HTM systems.
Consequently, the first step of using an HTM system is to convert a data source into an SDR using what we call an encoder. The encoder converts the native format of the data into an SDR that can be fed into an HTM system. The encoder is responsible for determining which output bits should be ones, and which should be zeros, for a given input value in such a way as to capture the important semantic characteristics of the data. Similar input values should produce highly overlapping SDRs. Source:https://www.researchgate.net/publication/301844094_Encoding_Data_for_HTM_Systems.
## The Encoding Process:

The encoding process is analogous to the functions of the sensory organs of humans and other animals. The cochlea, for instance, is a specialized structure that converts the frequencies and amplitudes of sounds in the environment into a sparse set of active neurons. The basic mechanism for this process comprises a set of inner hair cells organized in a row that are sensitive to different frequencies. When an appropriate sound frequency occurs, the hair cells stimulate neurons that
send the signal to the brain. The set of neurons that are triggered in this manner comprises the encoding of the sound as a Sparse Distributed Representation. 
One important aspect of the cochlear encoding process is that each hair cell responds to a range of frequencies, and the ranges overlap with other nearby hair cells. This characteristic provides redundancy in case some hair cells are damaged but also means that a given frequency will stimulate multiple cells, and two sounds with similar frequencies will have some overlap in the cells that are stimulated. This overlap between representations is how the semantic similarity of the data is captured in the representation.
The cochleae for different animals respond to different ranges of frequencies and have different resolutions for which they can distinguish differences in the frequencies. While very high-frequency sounds might be important for some animals to hear precisely, they might not be useful to others. Similarly, the design of an encoder is dependent on the type of data. The encoder must capture the semantic characteristics of the data that are important for your application. Source:https://www.researchgate.net/publication/301844094_Encoding_Data_for_HTM_Systems.

 **[Go to top &uarr;](#Overview)**
 
 ## Reconstructing the SP algorithm:
  
To “Reconstruct the SP algorithm” you could use the information of the connected synapses lying in the SP data structure. The first step would be to get the synapses with the function getConnectedSynapses.

Here is an example from the NuPIC Github repo:

![Capture](https://github.com/Neel1097/Team-ByteBaite_neocortexapi/assets/60136654/642e46ce-1018-4ea3-a278-2854aca7af32)

## Spatial Pooler Overview: 

In the HTM framework, the Spatial Pooler (SP) is a component responsible for creating sparse distributed representations (SDR) of input data. The primary goal of the Spatial Pooler is to transform input patterns into a stable and sparse representation that subsequent stages of the neural network can easily use.  

In the HTM framework, the Spatial Pooler (SP) is a component responsible for creating sparse distributed representations (SDR) of input data. The primary goal of the Spatial Pooler is to transform input patterns into a stable and sparse representation that can be easily used by subsequent stages of the neural network.  

Here's a simplified explanation of the Spatial Pooler's function in the HTM context:
1. Input Encoding: The SP takes in spatially and temporally encoded input patterns.
2. SDR: The SP transforms the dense input patterns into an SDR. These are characterized by the activation of only a small percentage of units, which helps in efficient memory usage and pattern recognition.
3. Stability and Invariance: The SP aims to create stable representations, and also helps in achieving some degree of invariance, making the network robust to variations in input.

## Phases of SP:
The SP consists of three phases, namely overlap, inhibition, and learning. Within an SP, there exist many columns. Each column has a unique set of proximal synapses connected via a proximal dendrite segment. Each proximal synapse tentatively connects to a single column from the input, i.e., each column in the SP connects to a specific attribute within the input. The input column’s activity level is used as the synaptic input, i.e., an active column is a “1” and an inactive column is a “0”.
To determine whether a synapse is connected or not, the synapse’s permanence value is checked. If the permanence value is at least equal to the connected threshold the synapse is connected; otherwise, it is unconnected. The permanence values are scalars in the closed interval [0,1]. 
Source:https://www.frontiersin.org/articles/10.3389/fncom.2017.00111/full

 
 
 **[Go to top &uarr;](#Overview)**





