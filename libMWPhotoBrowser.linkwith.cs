using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libMWPhotoBrowser.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true, Frameworks="ImageIO MessageUI Foundation")]
