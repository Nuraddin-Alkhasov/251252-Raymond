   M S B A M L   `   `   `  ����  251252-Raymond-25    /HMI.DialogRegion.Dashboard.Views.WidgetSelector   5   
   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   
   Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5   
   -   5          VisiWin.Controls.View   Name$  WS��5   
   $
��1920��5   
   $
��1080��6      DialogSurroundBrush#���   6%    J� Opacity$ 0Q�6X    � DataContext 5   
   0  *VisiWin.Extensions.AdapterBindingExtension     Name$ 	Dashboard��.��5
      � .+�5   
   � -   5         �Name$ border��5       J� RenderTransformOrigin$ 1, 0.5&�6   $
��1250��6>   $	��800��6K   $��Center=�6X   $��Center=�6u   z�5      �� 5       �� ScaleX$	 0.3Q�6!    �� ScaleY$	 0.3Q�6.   .+�5        VisiWin.Controls.Border  
�������$	 0.7Q�6,    �� CornerRadius$ 5��6:   	 J� Effect	 5      -  'System.Windows.Media.Effects.BlurEffect  5      
   Radius$
 10Q�6!   5      �� 5      
�������$��5q�6*   $��0q�65     BackgroundBrush#���  6I   $ 5��6x   ._�5      � $��	10,0,10,0q�6    � RowDefinitions 5      �� 5      $��70 �6(   �� 5      $��12 �6(   �� 5      $��* �6(   �� 5      $��12 �6(   �� 5      $��70 �6(   .+�5         VisiWin.Controls.TextBlock  -   5          Name$ 
HeaderText��5   #   $
��Left=�67   $��Center=�6R   
�������$��18(�6�   $
��Bold"�6�      LocalizableText$ @Dashboard.AddWidget��6�   $	��400��6�     VisiWin.Controls.Button  5       -   5          Name$ CancelButton��5        $��Right=�66   $	��Top=�6R     B_Close#���  6j   $��80��6�   $��40��6�      Text$ X��6�   $��0,0,0,0q�6�   ��6�   �� *Close+�� 5!      $��1��6   $	��Top=�6*    
 FP_Red#���  6B   $��2��6i   $ 2��6t   �� 5#      -   5         ��Name$ 
LayoutRoot��5#      $��2��61   $��0q�6>   
�������
������ ._�5$      �  � ColumnDefinitions 5%      �� 5&   "   $	��400 �63   �� 5'   "   $��* �63   .+�5)      � $��35��6#   .+�5*   "     $��Center=�6P   $��Stretch=�6k   $��16(�6�   
���   � 6/   �� *Name+6�   5+        5,      $��0��6(   $��
-5,-5,0,-5q�68   
�������$	 0.7Q�6`   $ 5��6n   	 5-   "     5.   &   $
 10Q�61   50        VisiWin.Controls.ListBox  51      -   5          Name$
 list��51   )   $��0��67   $��2q�6G     FP_BorderBrush#���  6[   $��0,0,5,0q�6�     LB_DashBoard#���  6�     FP_Black_Gradient#���  6,  $��Visible=�6]     AuthorizationRight$ 	Dashboard��6�  ��6�   �� *AvailableDashboardWidgets+ �� SelectedItem 6�   �� *SelectedDashboardWidget+ �� 
GroupStyle 52   "   (  "System.Windows.Controls.GroupStyle  53   &      ContainerStyle 54   *   �� 55   .    �� 
TargetType" ��64   .�56   2   ��  �� Property � �� �� Value 57   6   �� 58   :    �� 
TargetType" ��6J   .R�59   >   9�  9� 
IsExpanded . ��5:   B   �� 5;   F    �� Orientation$ 
Horizontal=�6Q   $��50��6j   .+�5<   J     $��10,0,0,0q�6}   $��Center=�6�   $��18(�6�   $
��Bold"�6�   
������� 6W   ��  �� Path$
 Name�6�   5=   G   .��5?   B   �� 5@   ?   5A   ;   5C   3   5D   /   5F   '   ��5H   "   �� 5I   &   " ��6,   .�5J   *   -   5        �� 5K   *    � ��
 �����6G   �� 5L   *    � �� 5N   .   �� 5P   2   " ��6B   .R�5Q   6   �� $��Border��6=   $��1,2,2,1q�6K   
������� J� SnapsToDevicePixels . ._�5R   :   �� $��40��6K   $��30,0,0,0q�6W    . 6j   5S   7    �� Triggers 5T   6   P� 5U   :     P� Property  �@��
IsSelected! P� Value! . . �5V   >   �� " �� 
TargetName$" Border��6E    � ��
 �����6o   �� 5W   >    � ��
 �   �6[   �� 5X   >    � ��$ SemiBold"�6[   5Y   ;   5[   3   5]   +   5^   '   5`        5a      $��1��6(   $	��810��68   $��-5q�6D   
�������$	 0.7Q�6d   $ 5��6r   	 5b   "     5c   &   $
 10Q�61   5e      �� 5f      $��1��6%   #���  65     FP_BackgroundBrush#���  6d   $	��800��6�   $��2q�6�   $ 3��6�   }�. ._�5g   "   	  VisiWin.Controls.Region	  -   5        # 	 Name$# DashboardPreviewRegion��5g   ,   $ J� IsHitTestVisible$ .  6L   5h      5i      5k      �� 5l      $��3��6   $��Bottom=�6*   #���  6E   $��2��6l   $ 2��6w   � 5n      $��4��6    5o      �� 5p      $��* �6/   �� 5q      $��* �6/   .+�5s        $��0��6$   $��50��64   $	��200��6@   $
��Left=�6L   %   LocalizableText$% @Buttons.Text42��6g     	B_Blue_ns#���  6�   &   AuthorizationRight$& 	Dashboard��6�   ��6�   �� *Add+6�     5t      $��1��6$   $��50��64   $	��200��6A   $��Right=�6M   $% @Buttons.Text13��6i    	 B_Red_ns#��� 	 6�   $��	0,10,0,10q�6�   ��6�   �� *Close+6�   5u      5v      5w      5x      5y      5z      