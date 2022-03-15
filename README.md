# BasicAvatarGenerator
A basic image generator that lets you create avatars with ease, and can be useful for any case when you're providing a service and need an avatar generated.
It provides a simple API, and uses ImageSharp as its only dependency.

# Getting started

At the moment, this library does not yet have a NuGet package, but we will have one very soon.
You can add this library to your project by simply cloning this repository, adding it to your solution, then adding a reference to it in your main project.

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
