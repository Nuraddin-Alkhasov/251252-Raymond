   M S B A M L   `   `   `  ����   251252-Raymond-22    ,HMI.DialogRegion.Maintenance.Views.MOH_TH_PO   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   $
��1920��$
��1080��   DialogSurroundBrush#���     J� Opacity$  0Q�.��� .+�� -    �Name$ border��$	��700��$	��545�� J� RenderTransformOrigin$ 1, 0.5&�$��Center=�$��Center=�z���  �� ScaleX$	 0.3Q� �� ScaleY$	 0.3Q�.+�  VisiWin.Controls.Border  
�������$	  0.7Q� �� CornerRadius$ 5�� J� Effect -  'System.Windows.Media.Effects.BlurEffect     Radius$ 10Q��� 
�������$��5q�$��0q�  BackgroundBrush#���  $ 5��._�� $��	10,0,10,0q� � RowDefinitions �� $��70 ��� $��12 ��� $��* ��� $��12 ��� $��70 �.+�   VisiWin.Controls.TextBlock  -   	  Name$	 
HeaderText��$
��Left=�$��Center=�
�������$��18(�$
��Bold"�
   LocalizableText$
 @Maintenance.Text57��$	��400��  VisiWin.Controls.Button  -     Name$ CancelButton��$��Right=�$	��Top=�  B_Close#���  $��80��$��40��   Text$ X��$��0,0,0,0q��� $��1��$	��Top=� 
 FP_Red#���  $��2��$ 2���� -    ��Name$ 
LayoutRoot��$��	10,0,10,0q�$��2��$��2q�
�������
������ ._�� .+��� $��14(� �� TabStripPlacement$
 Left=�$��10,0,0,0q�$��0q�#���  .@��� $��60��$	��200�� �� 
IsSelected .   	TI_Filter#���  $��
0,10,0,-10q���/  )VisiWin.Extensions.LocalizedTextExtension     LocalizedText$ @Maintenance.Text56��.���� .+��� $	��150��$��	10,0,10,0q�$
��Bold"�$��16(�
���   �$��3q�
���   ���6  0VisiWin.Extensions.LocalizedTextBindingExtension     LocalizableText$ @Maintenance.Text13��.����  �� Orientation$ Vertical=�$��Center=�$��Center=�.+�#  VisiWin.Controls.NumericVarIn    NVI_Main#���  $	��120��$��45��$��0,0,0,0q�   LocalizableUnitText$ @Units.h��*  $VisiWin.Controls.VariableBaseControl   VariableName$] WCPU2.PLC.Blocks.04 Tray handling.08 PO.01 Gripper.DB PO Gripper HMI.Parameter.PM.Time.H��   AuthorizationRight$ Maintenance��  #���  $	��120��$��45��$��0,10,0,0q�$ @Units.times��$b \CPU2.PLC.Blocks.04 Tray handling.08 PO.01 Gripper.DB PO Gripper HMI.Parameter.PM.State.Value��$ Maintenance���� $	��150��$��
10,10,10,0q�$	��410��$
��Bold"�$��16(�
���   �$��3q�
���   ���  $ @Maintenance.Text14��.���� $ Vertical=�$��Center=�$��Center=�.+��� $ 
Horizontal=�$��Center=�$��Center=�.+�$	  VisiWin.Controls.NumericVarOut	    NVO_Main#���  $	��120��$��45��$��0,0,10,0q� 	  LocalizableUnitText$ @Units.h��$Z TCPU2.PLC.Blocks.04 Tray handling.08 PO.01 Gripper.DB PO Gripper HMI.Actual.PM.Time.H��  -   $��45��$	��120��$
��Left=�   LocalizableText$ @Buttons.Text2�� 	 B_Red#���     AuthorizationRight$ Maintenance���� $ 
Horizontal=�$��Center=�$��Center=�$��0,10,0,0q�.+�	  #���  $	��120��$��45��$��0,0,10,0q�$ @Units.times��$_ YCPU2.PLC.Blocks.04 Tray handling.08 PO.01 Gripper.DB PO Gripper HMI.Actual.PM.State.Value��  -   $��45��$	��120��$
��Left=�$ @Buttons.Text2��#���  $ Maintenance���� $��60��$	��200�� . #���  $��
0,20,0,-20q���  $ @Maintenance.Text46��.���� .+��� $	��150��$��	10,0,10,0q�$
��Bold"�$��16(�
���   �$��3q�
���   ���  $ @Maintenance.Text13��.���� $ Vertical=�$��Center=�$��Center=�.+�  #���  $	��120��$��45��$��0,0,0,0q�$ @Units.h��$_ YCPU2.PLC.Blocks.04 Tray handling.08 PO.02 Traction.DB PO Traction HMI.Parameter.PM.Time.H��$ Maintenance��  #���  $	��120��$��45��$��0,10,0,0q�$ @Units.%��$d ^CPU2.PLC.Blocks.04 Tray handling.08 PO.02 Traction.DB PO Traction HMI.Parameter.PM.State.Value��$ Maintenance���� $	��150��$��
10,10,10,0q�$	��410��$
��Bold"�$��16(�
���   �$��3q�
���   ���  $ @Maintenance.Text14��.���� $ Vertical=�$��Center=�$��Center=�.+��� $ 
Horizontal=�$��Center=�$��Center=�.+�	  #���  $	��120��$��45��$��0,0,10,0q�$ @Units.h��$\ VCPU2.PLC.Blocks.04 Tray handling.08 PO.02 Traction.DB PO Traction HMI.Actual.PM.Time.H��  -   $��45��$	��120��$
��Left=�$ @Buttons.Text2��#���  $ Maintenance���� $ 
Horizontal=�$��Center=�$��Center=�$��0,10,0,0q�.+�	  #���  $	��120��$��45��$��0,0,10,0q�$ @Units.%��$a [CPU2.PLC.Blocks.04 Tray handling.08 PO.02 Traction.DB PO Traction HMI.Actual.PM.State.Value��  -   $��45��$	��120��$
��Left=�$ @Buttons.Text2��#���  $ Maintenance��{�.  �� $��60��$	��200�� . #���  $��
0,30,0,-30q���  $ @Maintenance.Text81��.���� .+��� $	��150��$��	10,0,10,0q�$
��Bold"�$��16(�
���   �$��3q�
���   ���  $ @Maintenance.Text13��.���� $ Vertical=�$��Center=�$��Center=�.+�  #���  $	��120��$��45��$��0,0,0,0q�$ @Units.h��$W QCPU2.PLC.Blocks.04 Tray handling.08 PO.03 Tilt.DB PO Tilt HMI.Parameter.PM.Time.H��$ Maintenance��  #���  $	��120��$��45��$��0,10,0,0q�$ @Units.%��$\ VCPU2.PLC.Blocks.04 Tray handling.08 PO.03 Tilt.DB PO Tilt HMI.Parameter.PM.State.Value��$ Maintenance���� $	��150��$��
10,10,10,0q�$	��410��$
��Bold"�$��16(�
���   �$��3q�
���   ���  $ @Maintenance.Text14��.���� $ Vertical=�$��Center=�$��Center=�.+��� $ 
Horizontal=�$��Center=�$��Center=�.+�	  #���  $	��120��$��45��$��0,0,10,0q�$ @Units.h��$T NCPU2.PLC.Blocks.04 Tray handling.08 PO.03 Tilt.DB PO Tilt HMI.Actual.PM.Time.H��  -	   $��45��$	��120��$
��Left=�$ @Buttons.Text2��#���  $ Maintenance���� $ 
Horizontal=�$��Center=�$��Center=�$��0,10,0,0q�.+�	  #���  $	��120��$��45��$��0,0,10,0q�$ @Units.%��$Y SCPU2.PLC.Blocks.04 Tray handling.08 PO.03 Tilt.DB PO Tilt HMI.Actual.PM.State.Value��  -
   $��45��$	��120��$
��Left=�$ @Buttons.Text2��#���  $ Maintenance��{�.  �� $��60��$	��200�� . #���  $��
0,40,0,-40q���  $ @Maintenance.Text90��.���� .+��� $	��150��$��	10,0,10,0q�$
��Bold"�$��16(�
���   �$��3q�
���   ���  $ @Maintenance.Text13��.���� $ Vertical=�$��Center=�$��Center=�.+�  #���  $	��120��$��45��$��0,0,0,0q�$ @Units.h��$[ UCPU2.PLC.Blocks.04 Tray handling.08 PO.04 Slider.DB PO Slider HMI.Parameter.PM.Time.H��$ Maintenance��  #���  $	��120��$��45��$��0,10,0,0q�$ @Units.times��$` ZCPU2.PLC.Blocks.04 Tray handling.08 PO.04 Slider.DB PO Slider HMI.Parameter.PM.State.Value��$ Maintenance���� $	��150��$��
10,10,10,0q�$	��410��$
��Bold"�$��16(�
���   �$��3q�
���   ���  $ @Maintenance.Text14��.���� $ Vertical=�$��Center=�$��Center=�.+��� $ 
Horizontal=�$��Center=�$��Center=�.+�	  #���  $	��120��$��45��$��0,0,10,0q�$ @Units.h��$X RCPU2.PLC.Blocks.04 Tray handling.08 PO.04 Slider.DB PO Slider HMI.Actual.PM.Time.H��  -   $��45��$	��120��$
��Left=�$ @Buttons.Text2��#���  $ Maintenance���� $ 
Horizontal=�$��Center=�$��Center=�$��0,10,0,0q�.+�	  #���  $	��120��$��45��$��0,0,10,0q�$ @Units.times��$] WCPU2.PLC.Blocks.04 Tray handling.08 PO.04 Slider.DB PO Slider HMI.Actual.PM.State.Value��  -   $��45��$	��120��$
��Left=�$ @Buttons.Text2��#���  $ Maintenance���� $��60��$	��200�� . #���  $��
0,50,0,-50q���  $ @Maintenance.Text91��.���� .+��� $	��150��$��	10,0,10,0q�$
��Bold"�$��16(�
���   �$��3q�
���   ���  $ @Maintenance.Text13��.���� $ Vertical=�$��Center=�$��Center=�.+�  #���  $	��120��$��45��$��0,0,0,0q�$ @Units.h��$U OCPU2.PLC.Blocks.04 Tray handling.08 PO.05 MGB.DB PO MGB HMI.Parameter.PM.Time.H��$ Maintenance��  #���  $	��120��$��45��$��0,10,0,0q�$ @Units.times��$Z TCPU2.PLC.Blocks.04 Tray handling.08 PO.05 MGB.DB PO MGB HMI.Parameter.PM.State.Value��$ Maintenance���� $	��150��$��
10,10,10,0q�$	��410��$
��Bold"�$��16(�
���   �$��3q�
���   ���  $ @Maintenance.Text14��.���� $ Vertical=�$��Center=�$��Center=�.+��� $ 
Horizontal=�$��Center=�$��Center=�.+�	  #���  $	��120��$��45��$��0,0,10,0q�$ @Units.h��$R LCPU2.PLC.Blocks.04 Tray handling.08 PO.05 MGB.DB PO MGB HMI.Actual.PM.Time.H��  -   $��45��$	��120��$
��Left=�$ @Buttons.Text2��#���  $ Maintenance���� $ 
Horizontal=�$��Center=�$��Center=�$��0,10,0,0q�.+�	  #���  $	��120��$��45��$��0,0,10,0q�$ @Units.times��$W QCPU2.PLC.Blocks.04 Tray handling.08 PO.05 MGB.DB PO MGB HMI.Actual.PM.State.Value��  -   $��45��$	��120��$
��Left=�$ @Buttons.Text2��#���  $ Maintenance���� $
��Left=�$��Stretch=�#���  $��	210,0,0,0q�$��4���� $��3��$��Bottom=�#���  $��2��$ 2��� $��4��.+�  -   $��50��$	��200��$��Center=�$ @Buttons.Text62��  	B_Gray_ns#���  