# Introduction
IF.NET is a free and open-source [.NET](https://dotnet.microsoft.com/en-us/) library for creating interactive fiction. 

## What Is Interactive Fiction
Interactive Fiction (or simply IF) refers to fiction in which players type commands to interact with a virtual world. For a good example, see the [Zork](https://en.wikipedia.org/wiki/Zork) series.

## Why IF.NET?
IF.NET is designed for interactive fiction authoring tailored to the needs of the programmer rather than the author. Languages like [Inform 7](https://ganelson.github.io/inform-website/) use natural language because it makes the process of writing IF a lot less like writing code than most authors want, whereas IF.NET offers programmers full control of their story in a manner not offered by Inform 7 and languages like it.

## IF.NET Concepts & Terminology
The **game** is represented as a **world** containing **rooms** containing **objects**. The player-character is controlled using **moves** such as `look`, `go south` or `read leaflet`. The game engine also listens for **events** such as [MovePlayerEvent](https://if.gordinator.org/api/IFDotNet.MovePlayerEvent.html) to control the world in a more centralised manner.
