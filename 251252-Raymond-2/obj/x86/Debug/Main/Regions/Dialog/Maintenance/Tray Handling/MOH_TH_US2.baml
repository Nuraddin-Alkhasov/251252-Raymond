   M S B A M L   `   `   `  ����  251252-Raymond-23    -HMI.DialogRegion.Maintenance.Views.MOH_TH_US2   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5      $
��1920��5      $
��1080��6      DialogSurroundBrush#���   6      J� Opacity$  0Q�6S   .��5      � .+�5	   
   � -   5         �Name$ border��5	      $	��700��6    $	��500��6,    J� RenderTransformOrigin$ 1, 0.5&�69   $��Center=�6X   $��Center=�6u   z�5
      �� 5       �� ScaleX$	 0.3Q�6!    �� ScaleY$	 0.3Q�6.   .+�5        VisiWin.Controls.Border  
�������$	  0.7Q�6,    �� CornerRadius$ 5��6:    J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 10Q�6!   5      �� 5      
�������$��5q�6+   $��0q�66     BackgroundBrush#���  6J   $ 5��6y   ._�5      � $��	10,0,10,0q�6    � RowDefinitions 5      �� 5      $��70 �6(   �� 5      $��12 �6(   �� 5      $��* �6(   �� 5      $��12 �6(   �� 5      $��70 �6(   .+�5         VisiWin.Controls.TextBlock  -   5        	  Name$	 
HeaderText��5   #   $
��Left=�67   $��Center=�6R   
�������$��18(�6�   $
��Bold"�6�   
   LocalizableText$
 @Maintenance.Text94��6�   $	��400��6�     VisiWin.Controls.Button  5      -   5          Name$ CancelButton��5       $��Right=�66   $	��Top=�6R     B_Close#���  6j   $��80��6�   $��40��6�      Text$ X��6�   $��0,0,0,0q�6�   6�   �� 5      $��1��6   $	��Top=�6*    
 FP_Red#���  6B   $��2��6i   $ 2��6t   �� 5      -   5         ��Name$ 
LayoutRoot��5      $��	10,0,10,0q�61   $��2��6D   $��2q�6Q   
�������
������ ._�5       � .+�5!      �� $��14(�6)    �� TabStripPlacement$
 Left=�67   $��10,0,0,0q�6Q   $��0q�6c   #���  6w   .@�5"   "   �� $��60��6*   $	��200��66    �� 
IsSelected .   	TI_Filter#���  6T   $��
0,10,0,-10q�6�   ��6y   /  )VisiWin.Extensions.LocalizedTextExtension     LocalizedText$ @Maintenance.Text23��.��5#   &   �� .+�5$   *   �� $	��150��64   $��	10,0,10,0q�6A   $
��Bold"�6�   $��16(�6�   
���   �$��3q�6�   
���   ���6T   6  0VisiWin.Extensions.LocalizedTextBindingExtension     LocalizableText$ @Maintenance.Text13��.��5%   .   ��  �� Orientation$ Vertical=�69   $��Center=�6P   $��Center=�6m   .+�5&   2   #  VisiWin.Controls.NumericVarIn    NVI_Main#���  6B   $	��120��6e   $��45��6q   $��0,0,0,0q�6}      LocalizableUnitText$ @Units.h��6�   *  $VisiWin.Controls.VariableBaseControl   VariableName$\ VCPU2.PLC.Blocks.04 Tray handling.09 US.02.01 Belt.DB US 2 Belt HMI.Parameter.PM.Time.H��6�      AuthorizationRight$ Maintenance��6    5'   2   #���  6B   $	��120��6e   $��45��6q   $��0,10,0,0q�6}   $ @Units.%��6�   $a [CPU2.PLC.Blocks.04 Tray handling.09 US.02.01 Belt.DB US 2 Belt HMI.Parameter.PM.State.Value��6�   $ Maintenance��6  5(   /   5)   +   �� 5*   *   $	��150��64   $��
10,10,10,0q�6A   $	��410��6U   $
��Bold"�6�   $��16(�6�   
���   �$��3q�6�   
���   ���6a     $ @Maintenance.Text14��.��5+   .   �� $ Vertical=�69   $��Center=�6P   $��Center=�6m   .+�5,   2   �� $ 
Horizontal=�6=   $��Center=�6V   $��Center=�6s   .+�5-   6   $	  VisiWin.Controls.NumericVarOut	    NVO_Main#���  6G   $	��120��6j   $��45��6v   $��0,0,10,0q�6�    	  LocalizableUnitText$ @Units.h��6�   $Y SCPU2.PLC.Blocks.04 Tray handling.09 US.02.01 Belt.DB US 2 Belt HMI.Actual.PM.Time.H��6�     5.   6   -   5        $��45��5.   @   $	��120��6L   $
��Left=�6X      LocalizableText$ @Buttons.Text2��6s    	 B_Red#���  6�      AuthorizationRight$ Maintenance��6�   50   3   �� 51   2   $ 
Horizontal=�6=   $��Center=�6V   $��Center=�6s   $��0,10,0,0q�6�   .+�52   6   	  #���  6G   $	��120��6j   $��45��6v   $��0,0,10,0q�6�   $ @Units.%��6�   $^ XCPU2.PLC.Blocks.04 Tray handling.09 US.02.01 Belt.DB US 2 Belt HMI.Actual.PM.State.Value��6�     53   6   -   5        $��45��53   @   $	��120��6L   $
��Left=�6X   $ @Buttons.Text2��6s   #���  6�   $ Maintenance��6�   {�.  6�   55   3   56   /   57   +   58   '   59   #   �� 5:   "   $��60��6*   $	��200��66    . #���  6T   $��
0,20,0,-20q�6�   ��6y     $ @Maintenance.Text12��.��5;   &   �� .+�5<   *   �� $	��150��64   $��	10,0,10,0q�6A   $
��Bold"�6�   $��16(�6�   
���   �$��3q�6�   
���   ���6T     $ @Maintenance.Text13��.��5=   .   �� $ Vertical=�69   $��Center=�6P   $��Center=�6m   .+�5>   2     #���  6B   $	��120��6e   $��45��6q   $��0,0,0,0q�6}   $ @Units.h��6�   $^ XCPU2.PLC.Blocks.04 Tray handling.09 US.01.02 Scale.DB US 1 Scale HMI.Parameter.PM.Time.H��6�   $ Maintenance��6    5?   2   #���  6B   $	��120��6e   $��45��6q   $��0,10,0,0q�6}   $ @Units.times��6�   $c ]CPU2.PLC.Blocks.04 Tray handling.09 US.01.02 Scale.DB US 1 Scale HMI.Parameter.PM.State.Value��6�   $ Maintenance��6  5@   /   5A   +   �� 5B   *   $	��150��64   $��
10,10,10,0q�6A   $	��410��6U   $
��Bold"�6�   $��16(�6�   
���   �$��3q�6�   
���   ���6a     $ @Maintenance.Text14��.��5C   .   �� $ Vertical=�69   $��Center=�6P   $��Center=�6m   .+�5D   2   �� $ 
Horizontal=�6=   $��Center=�6V   $��Center=�6s   .+�5E   6   	  #���  6G   $	��120��6j   $��45��6v   $��0,0,10,0q�6�   $ @Units.h��6�   $[ UCPU2.PLC.Blocks.04 Tray handling.09 US.01.02 Scale.DB US 1 Scale HMI.Actual.PM.Time.H��6�     5F   6   -   5        $��45��5F   @   $	��120��6L   $
��Left=�6X   $ @Buttons.Text2��6s   #���  6�   $ Maintenance��6�   5H   3   �� 5I   2   $ 
Horizontal=�6=   $��Center=�6V   $��Center=�6s   $��0,10,0,0q�6�   .+�5J   6   	  #���  6G   $	��120��6j   $��45��6v   $��0,0,10,0q�6�   $ @Units.times��6�   $` ZCPU2.PLC.Blocks.04 Tray handling.09 US.01.02 Scale.DB US 1 Scale HMI.Actual.PM.State.Value��6�     5K   6   -   5        $��45��5K   @   $	��120��6L   $
��Left=�6X   $ @Buttons.Text2��6s   #���  6�   $ Maintenance��6�   5M   3   5N   /   5O   +   5P   '   5Q   #   5S      �� 5U      $
��Left=�6(   $��Stretch=�6C   #���  6_   $��	210,0,0,0q�6   $��4��6�   5W      5[      �� 5\      $��3��6   $��Bottom=�6*   #���  6E   $��2��6l   $ 2��6w   � 5^      $��4��6   .+�5_        -	   5        $��50��5_   $   $	��200��61   $��Center=�6=   $ @Buttons.Text62��6Z     	B_Gray_ns#���  6�   5`      5a      5b      5c      5d      5e      