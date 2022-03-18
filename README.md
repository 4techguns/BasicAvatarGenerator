# BasicAvatarGenerator [![CodeFactor](https://www.codefactor.io/repository/github/4techguns/basicavatargenerator/badge)](https://www.codefactor.io/repository/github/4techguns/basicavatargenerator) ![NuGet Downloads](https://img.shields.io/nuget/dt/BasicAvatarGenerator) ![Version](https://img.shields.io/nuget/v/BasicAvatarGenerator) ![Commit rate](https://img.shields.io/github/commit-activity/w/4techguns/BasicAvatarGenerator)
A basic image generator that lets you create avatars with ease, and can be useful for any case when you're providing a service and need an avatar generated.
It provides a simple API, and uses ImageSharp as its only dependency.



# Getting started

Adding this library to your project should be as simple as adding the BasicAvatarGenerator NuGet package in your project.

Using the .NET CLI:
`dotnet add MyProjectName package BasicAvatarGenerator --version 2.1.0`

# Usage

Using the library is as simple as:

```cs
using BasicAvatarGenerator;

// ...

RandomColourLayer layer1 = new(0, 0, 128, 128);

Avatar avatar = new(128, 128, layer1);
avatar.FullGenerate("myAvatar.png");

```

Peep the wiki for more advanced examples!

# Contributing
Please see [CONTRIBUTING.md](https://github.com/4techguns/BasicAvatarGenerator/blob/master/CONTRIBUTING.md) for details on how to contribute to this library, and our code of conduct.
