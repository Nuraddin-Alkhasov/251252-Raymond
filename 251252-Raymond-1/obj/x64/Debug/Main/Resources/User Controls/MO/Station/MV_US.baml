   M S B A M L   `   `   `  ����W  S251252-Raymond-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=6505eeda710e1f37M+clr-namespace:HMI.Resources.UserControls.MOHMI.Resources.UserControls.MO  5   	   )    #HMI.Resources.UserControls.MO.MV_US   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5   	   6UC+clr-namespace:HMI.Resources.UserControls.MO   5   	   -   5          J� Opacity$  0Q�5   @   .��5      � -   5         �Name$ A��5      $y�Visible=�6   .+�5	   
   !  VisiWin.Controls.PictureBox     SymbolResourceKey$ MV_US��6   $��74��62   $	��170��6=   $��0,89,0,0q�6J   $
��Left=�6\   $	��Top=�6w    J� Effect 5
      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ Black��6#      
BlurRadius$ 3Q�61      	Direction$	 270Q�6A      Opacity$	 0.5Q�6R   5        5   
   $ MV_US��6   $��74��62   $	��170��6=   $��	93,88,0,0q�6J   $
��Left=�6]   $	��Top=�6x    5        5      $ Black��6#   $ 3Q�61   $	 270Q�6A   $	 0.5Q�6R   5      .   (HMI.Resources.UserControls.MO.MVMaterial  5   
   $��	14,99,0,0q�6   $y�Visible=�6+   $
��Left=�6@   $	��Top=�6[   $��46��6s   $	��129��6~      
IsMaterial$X RCPU2.PLC.Blocks.04 Tray handling.09 US.02.00 Main.DB US 2 PD.Belt.Charge.Available��5      	   SetLayer$X	 RCPU2.PLC.Blocks.04 Tray handling.09 US.02.00 Main.DB US 2 PD.Belt.Charge.Layer.Set��5      
   ActualLayer$[
 UCPU2.PLC.Blocks.04 Tray handling.09 US.02.00 Main.DB US 2 PD.Belt.Charge.Layer.Actual��5         Station$ 23��5         Header$ @Status.Text77��6'      Type$
 Belt��6B   
   CPU$
 CPU2��6P     5   
   $y�Visible=�6   $��
107,99,0,0q�6-   $
��Left=�6A   $	��Top=�6\   $��46��6t   $	��129��6   $X RCPU2.PLC.Blocks.04 Tray handling.09 US.01.00 Main.DB US 1 PD.Belt.Charge.Available��5      $X	 RCPU2.PLC.Blocks.04 Tray handling.09 US.01.00 Main.DB US 1 PD.Belt.Charge.Layer.Set��5      $[
 UCPU2.PLC.Blocks.04 Tray handling.09 US.01.00 Main.DB US 1 PD.Belt.Charge.Layer.Actual��5      $ 21��5       $ @Status.Text73��6'   $
 Belt��6A   $
 CPU2��6O   � 5"   
   $��
-5,262,0,0q�6   $
��Left=�6#   $	��Top=�6>   .+�5#      � -   5        $
 box2��5#      $  0Q�6!   .+�5$        $ MV_Box��6    $��86��6;   $��89��6F   $
��Left=�6R   $	��Top=�6m    5%        5&      $ Black��6+   $ 3Q�69   $	 270Q�6I   $	 0.5Q�6Z   5(        VisiWin.Controls.Border  5)      -   5          Name$ isMat2��5)      $  0Q�6,      FP_LightGreen_Gradient#���   68   $��82��6n   $��38��6y   $��1q�6�   
���   �$��2,2,0,0q�6�   $
��Left=�6�   $	��Top=�6�   5+         VisiWin.Controls.TextBlock  5,      -   5          Name$	 nr2��5,      $��2��6(   $��Center=�61   $��Bottom=�6N   $��0,0,0,5q�6i   $��16(�6z   $
��Bold"�6�   
�������   	BlinkMode$ 
Visibility=�6�     VisiWin.Controls.Button  5.      -   5          
B_Material#���  5.      $��96��6>   $��99��6I   $��-5q�6U   6a   50      � 52   
   $��
88,262,0,0q�6   $y�Visible=�6$   $
��Left=�69   $	��Top=�6T   .+�53      � -   5        $
 box1��53      $  0Q�6!   .+�54        $ MV_Box��6    $��86��6;   $��89��6F   $
��Left=�6R   $	��Top=�6m    55        56      $ Black��6+   $ 3Q�69   $	 270Q�6I   $	 0.5Q�6Z   58        59      -   5        $ isMat1��59      $  0Q�6,   #���   68   $��82��6n   $��38��6y   $��1q�6�   
���   �$��2,2,0,0q�6�   $
��Left=�6�   $	��Top=�6�   5;        5<      -	   5        $	 nr1��5<      $��1��6(   $��Center=�61   $��Bottom=�6N   $��0,0,0,5q�6i   $��16(�6z   $
��Bold"�6�   
�������$ 
Visibility=�6�     5>      -
   5        #���  5>      $��96��6>   $��99��6I   $��-5q�6V   6b   5@      5A      5B      