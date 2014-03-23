using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MWPhotoBrowser {

	[BaseType (typeof (UIToolbar))]
	public partial interface MWCaptionView {

		[Export ("initWithPhoto:")]
		IntPtr Constructor (MWPhoto photo);

		[Export ("setupCaption")]
		void SetupCaption ();

		[Export ("sizeThatFits:")]
		SizeF SizeThatFits (SizeF size);
	}

	[BaseType (typeof (NSObject))]
	public partial interface MWPhoto {

		[Export ("caption", ArgumentSemantic.Retain)]
		string Caption { get; set; }

		[Export ("image")]
		UIImage Image { get; }

		[Export ("photoURL")]
		NSUrl PhotoURL { get; }

		[Export ("filePath")]
		string FilePath { get; }

		[Static, Export ("photoWithImage:")]
		MWPhoto PhotoWithImage (UIImage image);

		[Static, Export ("photoWithFilePath:")]
		MWPhoto PhotoWithFilePath (string path);

		[Static, Export ("photoWithURL:")]
		MWPhoto PhotoWithURL (NSUrl url);

		[Export ("initWithImage:")]
		IntPtr Constructor (UIImage image);

		[Export ("initWithURL:")]
		IntPtr Constructor (NSUrl url);

		[Export ("initWithFilePath:")]
		IntPtr Constructor (string path);

		[Export ("underlyingImage", ArgumentSemantic.Retain)]
		UIImage UnderlyingImage { get; set; }

		[Export ("loadUnderlyingImageAndNotify")]
		void LoadUnderlyingImageAndNotify ();

		[Export ("performLoadUnderlyingImageAndNotify")]
		void PerformLoadUnderlyingImageAndNotify ();

		[Export ("unloadUnderlyingImage")]
		void UnloadUnderlyingImage ();

		[Export ("cancelAnyLoading")]
		void CancelAnyLoading ();
	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface MWPhotoBrowserDelegate {

		[Export ("numberOfPhotosInPhotoBrowser:")]
		int  numberOfPhotosInPhotoBrowser(MWPhotoBrowser photoBrowser);

		[Export ("photoBrowser:photoAtIndex:")]
		MWPhoto PhotoAtIndex (MWPhotoBrowser photoBrowser, uint index);

		[Export ("photoBrowser:thumbPhotoAtIndex:")]
		MWPhoto ThumbPhotoAtIndex (MWPhotoBrowser photoBrowser, uint index);

		[Export ("photoBrowser:captionViewForPhotoAtIndex:")]
		MWCaptionView CaptionViewForPhotoAtIndex (MWPhotoBrowser photoBrowser, uint index);

		[Export ("photoBrowser:didDisplayPhotoAtIndex:")]
		void DidDisplayPhotoAtIndex (MWPhotoBrowser photoBrowser, uint index);

		[Export ("photoBrowser:actionButtonPressedForPhotoAtIndex:")]
		void ActionButtonPressedForPhotoAtIndex (MWPhotoBrowser photoBrowser, uint index);

		[Export ("photoBrowser:isPhotoSelectedAtIndex:")]
		bool IsPhotoSelectedAtIndex (MWPhotoBrowser photoBrowser, uint index);

		[Export ("photoBrowser:photoAtIndex:selectedChanged:")]
		void PhotoAtIndex (MWPhotoBrowser photoBrowser, uint index, bool selected);
	}

	[BaseType (typeof (UIViewController))]
	public partial interface MWPhotoBrowser{ //: UIScrollViewDelegate, UIActionSheetDelegate, MFMailComposeViewControllerDelegate {

		[Export ("delegate", ArgumentSemantic.Assign)]
		MWPhotoBrowserDelegate Delegate { get; set; }

		[Export ("zoomPhotosToFill")]
		bool ZoomPhotosToFill { get; set; }

		[Export ("displayNavArrows")]
		bool DisplayNavArrows { get; set; }

		[Export ("displayActionButton")]
		bool DisplayActionButton { get; set; }

		[Export ("displaySelectionButtons")]
		bool DisplaySelectionButtons { get; set; }

		[Export ("alwaysShowControls")]
		bool AlwaysShowControls { get; set; }

		[Export ("enableGrid")]
		bool EnableGrid { get; set; }

		[Export ("startOnGrid")]
		bool StartOnGrid { get; set; }

		[Export ("currentIndex")]
		uint CurrentIndex { get; }

		[Export ("initWithPhotos:")]
		IntPtr Constructor (NSObject [] photosArray);

		[Export ("initWithDelegate:")]
		IntPtr Constructor (MWPhotoBrowserDelegate mwPhotoBrowserDelegate);

		[Export ("reloadData")]
		void ReloadData ();

		[Export ("currentPhotoIndex")]
		uint CurrentPhotoIndex { set; }

		[Export ("initialPageIndex")]
		uint InitialPageIndex { set; }

		[Export ("changeBackgroundColor:")]
		void ChangeBackgroundColor (UIColor color);

		[Export ("changeNavigationBarTintColor:")]
		void ChangeNavigationBarTintColor (UIColor color);

		[Export ("changeNavigationBarBackgroundTintColor:")]
		void ChangeNavigationBarBackgroundTintColor (UIColor color);

		[Export ("changeNavigationBarBackgroundImage:")]
		void ChangeNavigationBarBackgroundImage (UIImage image);

		[Export ("changeToolbarBackgroundTintColor:")]
		void ChangeToolbarBackgroundTintColor (UIColor color);

		[Export ("changeToolbarTintColor:")]
		void ChangeToolbarTintColor (UIColor color);

		[Export ("changeToolbarBackgroundImage:")]
		void ChangeToolbarBackgroundImage (UIImage image);

		[Export ("showNextPhotoAnimated:")]
		void ShowNextPhotoAnimated (bool animated);

		[Export ("showPreviousPhotoAnimated:")]
		void ShowPreviousPhotoAnimated (bool animated);
	}

}
//namespace SDWebImage
//{
//	[BaseType (typeof (UIView))]
//	[Model]
//	interface SDWebImageManagerDelegate
//	{
//		[Export ("webImageManager:didProgressWithPartialImage:forURL:userInfo:")]
//		void DidProgressWithPartialImage (SDWebImageManager imageManager, UIImage image, NSUrl url, NSDictionary info);
//
//		[Export ("webImageManager:didProgressWithPartialImage:forURL:")]
//		void DidProgressWithPartialImage (SDWebImageManager imageManager, UIImage image, NSUrl url);
//
//		[Export ("webImageManager:didFinishWithImage:forURL:userInfo:")]
//		void DidFinishWithImage (SDWebImageManager imageManager, UIImage image, NSUrl url, NSDictionary info);
//
//		[Export ("webImageManager:didFinishWithImage:forURL:")]
//		void DidFinishWithImage (SDWebImageManager imageManager, UIImage image, NSUrl url);
//
//		[Export ("webImageManager:didFinishWithImage:")]
//		void DidFinishWithImage (SDWebImageManager imageManager, UIImage image);
//
//		[Export ("webImageManager:didFailWithError:forURL:userInfo:")]
//		void DidFailWithError (SDWebImageManager imageManager, NSError error, NSUrl url, NSDictionary info);
//
//		[Export ("webImageManager:didFailWithError:forURL:")]
//		void DidFailWithError (SDWebImageManager imageManager, NSError error, NSUrl url);
//
//		[Export ("webImageManager:didFailWithError:")]
//		void DidFailWithError (SDWebImageManager imageManager, NSError error);
//	}
//
//	public delegate void SDWebImageSuccessBlock (UIImage image, bool cached);
//	public delegate void SDWebImageFailureBlock (NSError error);
//
//	[BaseType (typeof (NSObject))]
//	interface SDWebImageManager
//	{
//		[Static, Export ("sharedManager")]
//		SDWebImageManager SharedManager { get; }
//
//		[Export ("cancelForDelegate:")]
//		void CancelForDelegate (NSObject del);
//
//		[Bind ("setImageWithURL:")]
//		void SetImage ([Target] UIImageView view, NSUrl url);
//
//		[Bind ("setImageWithURL:")]
//		void SetImage ([Target] UIButton view, NSUrl url);
//
//		[Bind ("setBackgroundImageWithURL:")]
//		void SetBackgroundImage ([Target] UIButton view, NSUrl url);
//
//		[Export ("downloadWithURL:delegate:options:")]
//		void Download (NSUrl url, NSObject del, SDWebImageOptions options);
//
//		[Export ("downloadWithURL:delegate:options:success:failure:")]
//		void Download (NSUrl url, [NullAllowed]NSObject del, SDWebImageOptions options, SDWebImageSuccessBlock success, SDWebImageFailureBlock failure);
//	}
//
//	[BaseType (typeof (NSObject))]
//	interface SDImageCache
//	{
//		[Static, Export("sharedImageCache")]
//		SDImageCache SharedImageCache { get; }
//
//		[Static, Export ("setMaxCacheAge:")]
//		void SetMaxCacheAge (int age);
//
//		[Export("cleanDisk")]
//		void CleanDisk();
//
//		[Export("clearDisk")]
//		void ClearDisk();
//
//		[Export("getSize")]
//		int GetSize();
//	}
//}


