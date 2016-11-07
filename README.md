# Mobile_ChangeColor
A small cross-platform(Android and iOS) app that change the color of context based on input info.
Studio Setting:
	Xamarin Studio
	I have removed all the packages and cleared all the solution.
	You need to add package, and build the solution in order to run.
	In my package, I used version 2.3.1.114 Xamarin.Form in IOS , and in my adroid package, 
	you need to add version 23.0.13 Xamarin.Android.Support.Design, Xamarin.Android.Support.v4
	Xamarin.Android.Support.v7.AppCompat, Xamarin.Android.Support.v7.CardView, 
	Xamarin.Android.Support.v7.MediaRouter
	Both of IOS and Android are able to compile, and if you have any problem compiling, please try to rebuild.
	(IMPORTANT)For android: If compile errors says "Unzipping Failed ...." and "No resource found that ...",  
	Please manually remove all files in packages of Chen.Yinghe.PJ1.Droid, and add version 2.1.0.6529 Xamarin.Forms, and 23.0.13 support      files.(IMPORTANT)
	IOS simulator: iPhone SE iOS 10.0
	Android simulator: Android_Accelerated_x86 (ARMv7a will run extremely slowly)
	Android SDK: need to install Android SDK Tools, Android SDK Platform-tools, Android SDK Build-tools
	and Android 7.0 (API 24)
