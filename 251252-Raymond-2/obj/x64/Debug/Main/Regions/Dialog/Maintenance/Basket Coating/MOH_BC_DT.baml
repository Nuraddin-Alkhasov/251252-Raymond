   M S B A M L   `   `   `  ����  251252-Raymond-22    ,HMI.DialogRegion.Maintenance.Views.MOH_BC_DT   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5      $
��1920��5      $
��1080��6      DialogSurroundBrush#���   6      J� Opacity$  0Q�6S   .��5      � .+�5
   
   � -   5         �Name$ border��5
      $	��700��6    $	��500��6,    J� RenderTransformOrigin$ 1, 0.5&�69   $��Center=�6X   $��Center=�6u   z�5      �� 5       �� ScaleX$	 0.3Q�6!    �� ScaleY$	 0.3Q�6.   .+�5        VisiWin.Controls.Border  
�������$	  0.7Q�6,    �� CornerRadius$ 5��6:    J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 10Q�6!   5      �� 5      
�������$��5q�6+   $��0q�66     BackgroundBrush#���  6J   $ 5��6y   ._�5      � $��	10,0,10,0q�6    � RowDefinitions 5      �� 5      $��70 �6(   �� 5      $��12 �6(   �� 5      $��* �6(   �� 5      $��12 �6(   �� 5      $��70 �6(   .+�5         VisiWin.Controls.TextBlock  -   5        	  Name$	 
HeaderText��5   #   $
��Left=�67   $��Center=�6R   
�������$��18(�6�   $
��Bold"�6�   
   LocalizableText$
 @Maintenance.Text27��6�   $	��400��6�     VisiWin.Controls.Button  5      -   5          Name$ CancelButton��5       $��Right=�66   $	��Top=�6R     B_Close#���  6j   $��80��6�   $��40��6�      Text$ X��6�   $��0,0,0,0q�6�   6�   �� 5      $��1��6   $	��Top=�6*    
 FP_Red#���  6B   $��2��6i   $ 2��6t   �� 5       -   5         ��Name$ 
LayoutRoot��5       $��	10,0,10,0q�61   $��2��6D   $��2q�6Q   
�������
������ ._�5!      � .+�5"      �� $��14(�6)    �� TabStripPlacement$
 Left=�67   $��10,0,0,0q�6Q   $��0q�6c   #���  6w   .@�5#   "   �� $��60��6*   $	��200��66    �� 
IsSelected .   	TI_Filter#���  6T   $��
0,10,0,-10q�6�   ��6y   /  )VisiWin.Extensions.LocalizedTextExtension     LocalizedText$ @Maintenance.Text11��.��5$   &   �� .+�5%   *   �� $	��150��64   $��	10,0,10,0q�6A   $
��Bold"�6�   $��16(�6�   
���   �$��3q�6�   
���   ���6T   6  0VisiWin.Extensions.LocalizedTextBindingExtension     LocalizableText$ @Maintenance.Text13��.��5&   .   ��  �� Orientation$ Vertical=�69   $��Center=�6P   $��Center=�6m   .+�5'   2   #  VisiWin.Controls.NumericVarIn    NVI_Main#���  6B   $	��120��6e   $��45��6q   $��0,0,0,0q�6}      LocalizableUnitText$ @Units.h��6�   *  $VisiWin.Controls.VariableBaseControl   VariableName$Z TCPU1.PLC.Blocks.03 Basket coating.01 CD.01 Rotor.DB CD Rotor HMI.Parameter.PM.Time.H��6�      AuthorizationRight$ Maintenance��6    5(   2   #���  6B   $	��120��6e   $��45��6q   $��0,10,0,0q�6}   $ @Units.%��6�   $_ YCPU1.PLC.Blocks.03 Basket coating.01 CD.01 Rotor.DB CD Rotor HMI.Parameter.PM.State.Value��6�   $ Maintenance��6  5)   /   5*   +   �� 5+   *   $	��150��64   $��
10,10,10,0q�6A   $	��410��6U   $
��Bold"�6�   $��16(�6�   
���   �$��3q�6�   
���   ���6a     $ @Maintenance.Text14��.��5,   .   �� $ Vertical=�69   $��Center=�6P   $��Center=�6m   .+�5-   2   �� $ 
Horizontal=�6=   $��Center=�6V   $��Center=�6s   .+�5.   6   $	  VisiWin.Controls.NumericVarOut	    NVO_Main#���  6G   $	��120��6j   $��45��6v   $��0,0,10,0q�6�    	  LocalizableUnitText$ @Units.h��6�   $W QCPU1.PLC.Blocks.03 Basket coating.01 CD.01 Rotor.DB CD Rotor HMI.Actual.PM.Time.H��6�     5/   6   -   5        $��45��5/   @   $	��120��6L   $
��Left=�6X      LocalizableText$ @Buttons.Text2��6s    	 B_Red#���  6�      AuthorizationRight$ Maintenance��6�   51   3   �� 52   2   $ 
Horizontal=�6=   $��Center=�6V   $��Center=�6s   $��0,10,0,0q�6�   .+�53   6   	  #���  6G   $	��120��6j   $��45��6v   $��0,0,10,0q�6�   $ @Units.%��6�   $\ VCPU1.PLC.Blocks.03 Basket coating.01 CD.01 Rotor.DB CD Rotor HMI.Actual.PM.State.Value��6�     54   6   -   5        $��45��54   @   $	��120��6L   $
��Left=�6X   $ @Buttons.Text2��6s   #���  6�   $ Maintenance��6�   {�.  6�   56   3   57   /   58   +   59   '   5:   #   �� 5;   "   $��60��6*   $	��200��66    . #���  6T   $��
0,20,0,-20q�6�   ��6y     $ @Maintenance.Text33��.��5<   &   �� .+�5=   *   �� $	��150��64   $��	10,0,10,0q�6A   $
��Bold"�6�   $��16(�6�   
���   �$��3q�6�   
���   ���6T     $ @Maintenance.Text13��.��5>   .   �� $ Vertical=�69   $��Center=�6P   $��Center=�6m   .+�5?   2     #���  6B   $	��120��6e   $��45��6q   $��0,0,0,0q�6}   $ @Units.h��6�   $Z TCPU1.PLC.Blocks.03 Basket coating.01 CD.05 Latch.DB CD Latch HMI.Parameter.PM.Time.H��6�   $ Maintenance��6    5@   2   #���  6B   $	��120��6e   $��45��6q   $��0,10,0,0q�6}   $ @Units.times��6�   $_ YCPU1.PLC.Blocks.03 Basket coating.01 CD.05 Latch.DB CD Latch HMI.Parameter.PM.State.Value��6�   $ Maintenance��6  5A   /   5B   +   �� 5C   *   $	��150��64   $��
10,10,10,0q�6A   $	��410��6U   $
��Bold"�6�   $��16(�6�   
���   �$��3q�6�   
���   ���6a     $ @Maintenance.Text14��.��5D   .   �� $ Vertical=�69   $��Center=�6P   $��Center=�6m   .+�5E   2   �� $ 
Horizontal=�6=   $��Center=�6V   $��Center=�6s   .+�5F   6   	  #���  6G   $	��120��6j   $��45��6v   $��0,0,10,0q�6�   $ @Units.h��6�   $W QCPU1.PLC.Blocks.03 Basket coating.01 CD.05 Latch.DB CD Latch HMI.Actual.PM.Time.H��6�     5G   6   -   5        $��45��5G   @   $	��120��6L   $
��Left=�6X   $ @Buttons.Text2��6s   #���  6�   $ Maintenance��6�   5I   3   �� 5J   2   $ 
Horizontal=�6=   $��Center=�6V   $��Center=�6s   $��0,10,0,0q�6�   .+�5K   6   	  #���  6G   $	��120��6j   $��45��6v   $��0,0,10,0q�6�   $ @Units.times��6�   $\ VCPU1.PLC.Blocks.03 Basket coating.01 CD.05 Latch.DB CD Latch HMI.Actual.PM.State.Value��6�     5L   6   -   5        $��45��5L   @   $	��120��6L   $
��Left=�6X   $ @Buttons.Text2��6s   #���  6�   $ Maintenance��6�   5N   3   5O   /   5P   +   5Q   '   5R   #   �� 5S   "   $��60��6*   $	��200��66    . #���  6T   $��
0,30,0,-30q�6�   ��6y     $ @Maintenance.Text62��.��5T   &   �� .+�5U   *   �� $	��150��64   $��	10,0,10,0q�6A   $
��Bold"�6�   $��16(�6�   
���   �$��3q�6�   
���   ���6T     $ @Maintenance.Text13��.��5V   .   �� $ Vertical=�69   $��Center=�6P   $��Center=�6m   .+�5W   2     #���  6B   $	��120��6e   $��45��6q   $��0,0,0,0q�6}   $ @Units.h��6�   $Z TCPU1.PLC.Blocks.03 Basket coating.01 CD.05 Latch.DB CD Latch HMI.Parameter.PM.Time.H��6�   $ Maintenance��6    5X   2   #���  6B   $	��120��6e   $��45��6q   $��0,10,0,0q�6}   $ @Units.times��6�   $_ YCPU1.PLC.Blocks.03 Basket coating.01 CD.05 Latch.DB CD Latch HMI.Parameter.PM.State.Value��6�   $ Maintenance��6  5Y   /   5Z   +   �� 5[   *   $	��150��64   $��
10,10,10,0q�6A   $	��410��6U   $
��Bold"�6�   $��16(�6�   
���   �$��3q�6�   
���   ���6a     $ @Maintenance.Text14��.��5\   .   �� $ Vertical=�69   $��Center=�6P   $��Center=�6m   .+�5]   2   �� $ 
Horizontal=�6=   $��Center=�6V   $��Center=�6s   .+�5^   6   	  #���  6G   $	��120��6j   $��45��6v   $��0,0,10,0q�6�   $ @Units.h��6�   $W QCPU1.PLC.Blocks.03 Basket coating.01 CD.05 Latch.DB CD Latch HMI.Actual.PM.Time.H��6�     5_   6   -	   5        $��45��5_   @   $	��120��6L   $
��Left=�6X   $ @Buttons.Text2��6s   #���  6�   $ Maintenance��6�   5a   3   �� 5b   2   $ 
Horizontal=�6=   $��Center=�6V   $��Center=�6s   $��0,10,0,0q�6�   .+�5c   6   	  #���  6G   $	��120��6j   $��45��6v   $��0,0,10,0q�6�   $ @Units.times��6�   $\ VCPU1.PLC.Blocks.03 Basket coating.01 CD.05 Latch.DB CD Latch HMI.Actual.PM.State.Value��6�     5d   6   -
   5        $��45��5d   @   $	��120��6L   $
��Left=�6X   $ @Buttons.Text2��6s   #���  6�   $ Maintenance��6�   5f   3   5g   /   5h   +   5i   '   5j   #   5k      �� 5m      $
��Left=�6(   $��Stretch=�6C   #���  6_   $��	210,0,0,0q�6   $��4��6�   5o      5s      �� 5t      $��3��6   $��Bottom=�6*   #���  6E   $��2��6l   $ 2��6w   � 5v      $��4��6   .+�5w        -   5        $��50��5w   $   $	��200��61   $��Center=�6=   $ @Buttons.Text62��6Z     	B_Gray_ns#���  6�   5x      5y      5z      5{      5|      5}      