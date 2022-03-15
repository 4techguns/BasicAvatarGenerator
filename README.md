# BasicAvatarGenerator
A basic image generator that lets you create avatars with ease, and can be useful for any case when you're providing a service and need an avatar generated.
It provides a simple API, and uses ImageSharp as its only dependency.



# Getting started

Adding this library to your project should be as simple as adding the BasicAvatarGenerator NuGet package in your project.

Using the .NET CLI:
`dotnet add MyProjectName package BasicAvatarGenerator --version 1.0.0`

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

```
Copyright (C) 2022  4techguns

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.```
