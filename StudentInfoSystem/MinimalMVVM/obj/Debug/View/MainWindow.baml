   M S B A M L   `   `   `  ????F  BMinimalMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MinimalMVVM.ViewModelMinimalMVVM.ViewModel  5   	   3clr-namespace:MinimalMVVM.ViewMinimalMVVM.View  5   	   !    MinimalMVVM.View.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   9	ViewModel#clr-namespace:MinimalMVVM.ViewModel     5   	   /Viewclr-namespace:MinimalMVVM.View     5   	     ? Title$  
MainWindow??5   	   $	??366??6   $	??300??6)    ? DataContext 5
      %   MinimalMVVM.ViewModel.Presenter  5   
    J? InputBindings 5      ?? 5   
   
 ?? Key$ Enter??6    ?? Command 6!   ?? *ConvertTextCommand+.??5      ?? $	??336??6   .+?5   
   ?? 
????  ?$??5,5,5,0q?6"   .??63   Text To Convert6D   ?? 5   
   $??5q?6Q   ??6   ?? *
SomeText+ ?? UpdateSourceTrigger$ PropertyChanged=?6Q   ?? 5   
   
????  ?$??5,5,5,0q?6"   .??63   	History6<   ?? 5   
   $	??200??6   $??5q?6!   ??6,   ?? *	History+?? 5   
   $??5q?6   ??6   ?? *ConvertTextCommand+.??6E   	Convert6N   5      5      