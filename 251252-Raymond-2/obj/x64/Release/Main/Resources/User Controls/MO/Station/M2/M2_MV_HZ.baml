   M S B A M L   `   `   `  ����   251252-Raymond-2,    &HMI.Resources.UserControls.MO.M2_MV_HZ   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   -     J� Opacity$  0Q�.��� .+��� -    ��Name$ A�� �� Orientation$ 
Horizontal=�.+�� -    �Name$ HZ�� � ColumnDefinitions �� $��* �.+�!  VisiWin.Controls.PictureBox     SymbolResourceKey$ MV_HZ��$	��165��$	��299��$��3q�$��2��$
��Left=�$	��Top=� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$	 Red��   
BlurRadius$ 20Q�	   	Direction$	 90Q�
   Opacity$	
 0.5Q�'  !VisiWin.Controls.NavigationButton  -     Name$ HZ1Ex��$��60��$	��100��$��13(�$��SemiBold"� 
  B_Gray#���     VisiWin.Controls.Button   CornerRadius$ 4��   LocalizableText$ @MachineOverview.Text21��   ViewName$ 	M2_HZ1_EF��   
RegionName$ DialogRegion1��$��	0,-65,0,0q�$	��Top=�$��Center=�
 � Tag 1  +VisiWin.Extensions.VariableBindingExtension     VariableName$[ UCPU4.PLC.Blocks.04 Tray handling.06 HZ.01.02 Exhaust.DB HZ 1 Exhaust HMI.Actual.State��� $	��100��$��60��$	��Top=�$��Center=�$��0,17,0,0q�.+�  {�.  $  1Q�  	B_Gray_ns#���  $��0,5,0,0q�$��13(�$��SemiBold"�$ @MachineOverview.Text56��$	��Top=�   $c ]CPU4.PLC.Blocks.04 Tray handling.06 HZ.01.01 Circulation.DB HZ 1 Circulation HMI.Actual.State��$  VisiWin.Controls.NumericVarOut  -     Name$
 HZ1F��$��0,0,3,0q�  NVO_Main#���  $��30��   LocalizableUnitText$ 
@Units.rpm��   Value$
 2500Q�*  $VisiWin.Controls.VariableBaseControl   TextAlignment$ Center=�$��Bottom=�   FormatString$ 0��$��2,0,2,2q�� $	��100��$��60��$	��Top=�$��Center=�$��0,92,0,0q�.+�  {�.  $  1Q�#���  $��0,5,0,0q�$��13(�$��SemiBold"�$ @MachineOverview.Text22��$	��Top=�   $[ UCPU4.PLC.Blocks.04 Tray handling.06 HZ.01.03 Heating.DB HZ 1 Heating HMI.Actual.State��  -   $
 HZ1T��$��0,0,3,0q�#���  $��30��$ @Units.C��$	 500Q�$ Center=�$��Bottom=�$ 0��$��2,0,2,2q�   VisiWin.Controls.TextBlock  $��1��$
��Left=�$��Bottom=�$��
17,0,0,106q�$��16(�$
��Bold"�
�������   	BlinkMode$ 
Visibility=�  -   $��-5,-5,-5,-5q�  	B_Station#���  