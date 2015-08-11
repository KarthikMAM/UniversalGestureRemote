# GestureRecognition

This is a prototype implementation of the library <b>GestureRecognition.cs</b> to show the various gestures currently avilable. 

This library has been developed to be simple and fast. This library is still in its prototype form and will be developed in the future to be a complete and a standard library that can be used for real-time application developments. Follow the steps below to add the features of this library in your application.

<h4>STEPS</h4>
<ul>
  <li>Download the file in this project named <a href="https://github.com/KarthikMAM/GestureRecognition/blob/master/GestureRecognition/GestureRecognition.cs">GestureRecognition.cs</a>
  <li>Import this file to your C# project
  <li>Create a new object for the class <b>GestureRecognition</b>. The construtor needs to take the following parameters namely the <b>MainThread</b> and the <b>COM PORT</b> where the bluetooth of the arduino and the bluetooth of the computer are interfaced.
  <li>To find out the COM port open the BluetoothSettings->COM PORTS and find the COM PORT where the device is connected.
  <li>No create a ProgressChanged event handler for the <b>sampler</b> BackgroundWorker object. 
  <li>The progress precentage is the required gesture.
  <li>Implement the logic using this in the ProgressChanged event handler.
</ul>

<h4>CURRENTLY AVILABLE GESTURES</h4>
<ul>
  <li>0 - NEUTRAL
  <li>1 - LEFT
  <li>2 - RIGHT
</ul>
