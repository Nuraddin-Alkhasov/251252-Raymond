   M S B A M L   `   `   `  ����  251252-Raymond-15    /HMI.DialogRegion.Dashboard.Views.WidgetSelector   5   
   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   
   Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5   
   -   5          VisiWin.Controls.View   Name$  WS��5   
   $
��1920��5   
   $
��1080��6      DialogSurroundBrush#���   6%    J� Opacity$ 0Q�6X    � DataContext 5   
   0  *VisiWin.Extensions.AdapterBindingExtension     Name$ 	Dashboard��.��5
      � .+�5   
   � -   5         �Name$ border��5       J� RenderTransformOrigin$ 1, 0.5&�6   $
��1250��6>   $	��800��6K   $��Center=�6X   $��Center=�6u   z�5      �� 5       �� ScaleX$	 0.3Q�6!    �� ScaleY$	 0.3Q�6.   .+�5        VisiWin.Controls.Border  
�������$	 0.7Q�6,    �� CornerRadius$ 5��6:   	 J� Effect	 5      -  'System.Windows.Media.Effects.BlurEffect  5      
   Radius$
 10Q�6!   5      �� 5      
�������$��5q�6*   $��0q�65     BackgroundBrush#���  6I   $ 5��6x   ._�5      � $��	10,0,10,0q�6    � RowDefinitions 5      �� 5      $��70 �6(   �� 5      $��12 �6(   �� 5      $��* �6(   �� 5      $��12 �6(   �� 5      $��70 �6(   .+�5         VisiWin.Controls.TextBlock  -   5          Name$ 
HeaderText��5   #   $
��Left=�67   $��Center=�6R   
�������$��18(�6�   $
��Bold"�6�      LocalizableText$ @Dashboard.AddWidget��6�   $	��400��6�     VisiWin.Controls.Button  5      -   5          Name$ CancelButton��5       $��Right=�66   $	��Top=�6R     B_Close#���  6j   $��80��6�   $��40��6�      Text$ X��6�   $��0,0,0,0q�6�   ��6�   �� *Close+�� 5       $��1��6   $	��Top=�6*    
 FP_Red#���  6B   $��2��6i   $ 2��6t   �� 5"      -   5         ��Name$ 
LayoutRoot��5"      $��2��61   $��0q�6>   
�������
������ ._�5#      �  � ColumnDefinitions 5$      �� 5%   "   $	��400 �63   �� 5&   "   $��* �63   .+�5(      � $��35��6#   .+�5)   "     $��Center=�6P   $��Stretch=�6k   $��16(�6�   
���   � 6/   �� *Name+6�   5*        5+      $��0��6(   $��
-5,-5,0,-5q�68   
�������$	 0.7Q�6`   $ 5��6n   	 5,   "     5-   &   $
 10Q�61   5/        VisiWin.Controls.ListBox  50      -   5          Name$
 list��50   )   $��0��67   $��2q�6G     FP_BorderBrush#���  6[   $��0,0,5,0q�6�     LB_DashBoard#���  6�     FP_Black_Gradient#���  6,  $��Visible=�6]     AuthorizationRight$ 	Dashboard��6�  ��6�   �� *AvailableDashboardWidgets+ �� SelectedItem 6�   �� *SelectedDashboardWidget+ �� 
GroupStyle 51   "   (  "System.Windows.Controls.GroupStyle  52   &      ContainerStyle 53   *   �� 54   .    �� 
TargetType" ��64   .�55   2   ��  �� Property � �� �� Value 56   6   �� 57   :    �� 
TargetType" ��6J   .R�58   >   9�  9� 
IsExpanded . ��59   B   �� 5:   F    �� Orientation$ 
Horizontal=�6Q   $��50��6j   .+�5;   J     $��10,0,0,0q�6}   $��Center=�6�   $��18(�6�   $
��Bold"�6�   
������� 6W   ��  �� Path$
 Name�6�   5<   G   .��5>   B   �� 5?   ?   5@   ;   5B   3   5C   /   5E   '   ��5G   "   �� 5H   &   " ��6,   .�5I   *   -   5        �� 5J   *    � ��
 �����6G   �� 5K   *    � �� 5M   .   �� 5O   2   " ��6B   .R�5P   6   �� $��Border��6=   $��1,2,2,1q�6K   
������� J� SnapsToDevicePixels . ._�5Q   :   �� $��40��6K   $��30,0,0,0q�6W    . 6j   5R   7    �� Triggers 5S   6   P� 5T   :     P� Property  �@��
IsSelected! P� Value! . . �5U   >   �� " �� 
TargetName$" Border��6E    � ��
 �����6o   �� 5V   >    � ��
 �   �6[   �� 5W   >    � ��$ SemiBold"�6[   5X   ;   5Z   3   5\   +   5]   '   5_        5`      $��1��6(   $	��810��68   $��-5q�6D   
�������$	 0.7Q�6d   $ 5��6r   	 5a   "     5b   &   $
 10Q�61   5d      �� 5e      $��1��6%   #���  65     FP_BackgroundBrush#���  6d   $	��800��6�   $��2q�6�   $ 3��6�   }�. ._�5f   "   	  VisiWin.Controls.Region	  -   5        # 	 Name$# DashboardPreviewRegion��5f   ,   $ J� IsHitTestVisible$ .  6L   5g      5h      5j      �� 5k      $��3��6   $��Bottom=�6*   #���  6E   $��2��6l   $ 2��6w   � 5m      $��4��6    5n      �� 5o      $��* �6/   �� 5p      $��* �6/   .+�5r        $��0��6$   $��50��64   $	��200��6@   $
��Left=�6L   %   LocalizableText$% @Buttons.Text42��6g     	B_Blue_ns#���  6�   &   AuthorizationRight$& 	Dashboard��6�   ��6�   �� *Add+6�     5s      $��1��6$   $��50��64   $	��200��6A   $��Right=�6M   $% @Buttons.Text13��6i    	 B_Red_ns#��� 	 6�   $��	0,10,0,10q�6�   ��6�   �� *Close+6�   5t      5u      5v      5w      5x      5y      