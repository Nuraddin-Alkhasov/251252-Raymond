   M S B A M L   `   `   `  ����   251252-Raymond-23    -HMI.DialogRegion.Maintenance.Views.MOH_BH_ST1   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   $
��1920��$
��1080��   DialogSurroundBrush#���     J� Opacity$  0Q�.��� .+�� -    �Name$ border��$	��700��$	��500�� J� RenderTransformOrigin$ 1, 0.5&�$��Center=�$��Center=�z���  �� ScaleX$	 0.3Q� �� ScaleY$	 0.3Q�.+�  VisiWin.Controls.Border  
�������$	  0.7Q� �� CornerRadius$ 5�� J� Effect -  'System.Windows.Media.Effects.BlurEffect     Radius$ 10Q��� 
�������$��5q�$��0q�  BackgroundBrush#���  $ 5��._�� $��	10,0,10,0q� � RowDefinitions �� $��70 ��� $��12 ��� $��* ��� $��12 ��� $��70 �.+�   VisiWin.Controls.TextBlock  -   	  Name$	 
HeaderText��$
��Left=�$��Center=�
�������$��18(�$
��Bold"�
   LocalizableText$
 @Maintenance.Text38��$	��400��  VisiWin.Controls.Button  -     Name$ CancelButton��$��Right=�$	��Top=�  B_Close#���  $��80��$��40��   Text$ X��$��0,0,0,0q��� $��1��$	��Top=� 
 FP_Red#���  $��2��$ 2���� -    ��Name$ 
LayoutRoot��$��	10,0,10,0q�$��2��$��2q�
�������
������ ._�� .+��� $��14(� �� TabStripPlacement$
 Left=�$��10,0,0,0q�$��0q�#���  .@��� -    ��Name$
 btn1��$��60��$	��200�� �� 
IsSelected .   	TI_Filter#���  $��
0,10,0,-10q���/  )VisiWin.Extensions.LocalizedTextExtension     LocalizedText$ @Maintenance.Text42��.���� .+��� $	��150��$��	10,0,10,0q�$
��Bold"�$��16(�
���   �$��3q�
���   ���6  0VisiWin.Extensions.LocalizedTextBindingExtension     LocalizableText$ @Maintenance.Text13��.����  �� Orientation$ Vertical=�$��Center=�$��Center=�.+�#  VisiWin.Controls.NumericVarIn    NVI_Main#���  $	��120��$��45��$��0,0,0,0q�   LocalizableUnitText$ @Units.h��*  $VisiWin.Controls.VariableBaseControl   VariableName$b \CPU1.PLC.Blocks.02 Basket handling.03 ST.01.01 Inside.DB ST 1 Inside HMI.Parameter.PM.Time.H��   AuthorizationRight$ Maintenance��  #���  $	��120��$��45��$��0,10,0,0q�$ @Units.times��$g aCPU1.PLC.Blocks.02 Basket handling.03 ST.01.01 Inside.DB ST 1 Inside HMI.Parameter.PM.State.Value��$ Maintenance���� $	��150��$��
10,10,10,0q�$	��410��$
��Bold"�$��16(�
���   �$��3q�
���   ���  $ @Maintenance.Text14��.���� $ Vertical=�$��Center=�$��Center=�.+��� $ 
Horizontal=�$��Center=�$��Center=�.+�$	  VisiWin.Controls.NumericVarOut	    NVO_Main#���  $	��120��$��45��$��0,0,10,0q� 	  LocalizableUnitText$ @Units.h��$_ YCPU1.PLC.Blocks.02 Basket handling.03 ST.01.01 Inside.DB ST 1 Inside HMI.Actual.PM.Time.H��  -   $��45��$	��120��$
��Left=�   LocalizableText$ @Buttons.Text2�� 	 B_Red#���     AuthorizationRight$ Maintenance���� $ 
Horizontal=�$��Center=�$��Center=�$��0,10,0,0q�.+�	  #���  $	��120��$��45��$��0,0,10,0q�$ @Units.times��$d ^CPU1.PLC.Blocks.02 Basket handling.03 ST.01.01 Inside.DB ST 1 Inside HMI.Actual.PM.State.Value��  -   $��45��$	��120��$
��Left=�$ @Buttons.Text2��#���  $ Maintenance���� -   $
 btn2��$��60��$	��200�� . #���  $��
0,20,0,-20q���  $ @Maintenance.Text40��.���� .+��� $	��150��$��	10,0,10,0q�$
��Bold"�$��16(�
���   �$��3q�
���   ���  $ @Maintenance.Text13��.���� $ Vertical=�$��Center=�$��Center=�.+�  #���  $	��120��$��45��$��0,0,0,0q�$ @Units.h��$d ^CPU1.PLC.Blocks.02 Basket handling.03 ST.01.02 Outside.DB ST 1 Outside HMI.Parameter.PM.Time.H��$ Maintenance��  #���  $	��120��$��45��$��0,10,0,0q�$ @Units.times��$i cCPU1.PLC.Blocks.02 Basket handling.03 ST.01.02 Outside.DB ST 1 Outside HMI.Parameter.PM.State.Value��$ Maintenance���� $	��150��$��
10,10,10,0q�$	��410��$
��Bold"�$��16(�
���   �$��3q�
���   ���  $ @Maintenance.Text14��.���� $ Vertical=�$��Center=�$��Center=�.+��� $ 
Horizontal=�$��Center=�$��Center=�.+�	  #���  $	��120��$��45��$��0,0,10,0q�$ @Units.h��$a [CPU1.PLC.Blocks.02 Basket handling.03 ST.01.02 Outside.DB ST 1 Outside HMI.Actual.PM.Time.H��  -	   $��45��$	��120��$
��Left=�$ @Buttons.Text2��#���  $ Maintenance���� $ 
Horizontal=�$��Center=�$��Center=�$��0,10,0,0q�.+�	  #���  $	��120��$��45��$��0,0,10,0q�$ @Units.times��$f `CPU1.PLC.Blocks.02 Basket handling.03 ST.01.02 Outside.DB ST 1 Outside HMI.Actual.PM.State.Value��  -
   $��45��$	��120��$
��Left=�$ @Buttons.Text2��#���  $ Maintenance���� $
��Left=�$��Stretch=�#���  $��	210,0,0,0q�$��4���� $��3��$��Bottom=�#���  $��2��$ 2��� $��4��.+�  -   $��50��$	��200��$��Center=�$ @Buttons.Text62��  	B_Gray_ns#���  