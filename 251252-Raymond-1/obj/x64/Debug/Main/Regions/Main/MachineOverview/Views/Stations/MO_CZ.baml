   M S B A M L   `   `   `  ����W  S251252-Raymond-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=6505eeda710e1f37M+clr-namespace:HMI.Resources.UserControls.MOHMI.Resources.UserControls.MO  5          HMI.MainRegion.MO.MO_CZ   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5      6UC+clr-namespace:HMI.Resources.UserControls.MO   5         FP_Black_Gradient#���   5      $
��1832��66   $
��1000��6C   .��5	      � -   5          �Name$  
LayoutRoot��5	       � RowDefinitions 5
   
   �� 5      $	��110 �6   �� 5      $��* �6   .+�5   
   � $��1��6   .+�5      !  VisiWin.Controls.PictureBox     SymbolResourceKey$	 BCZ��6   $
��1457��65   $	��418��6B   $��
100,0,0,90q�6O   $
��Left=�6c   $��Bottom=�6~    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$
 Blue��6'      
BlurRadius$ 30Q�64      	Direction$	 270Q�6E      Opacity$ 1Q�6V   5      *   $HMI.Resources.UserControls.MO.CZTray  5      $��1401,500,0,0q�6   $
��Left=�6.   $	��Top=�6I   �� 5      $��
140,80,0,0q�6   $
��Left=�6-   $	��Top=�6H    �� Orientation$ 
Horizontal=�6`   .+�5      �� .+�5        VisiWin.Controls.GroupBox    	GB_Group2#���  6"   $
��Left=�6F   $	��Top=�6a   $	��250��6y   $��0,5,0,0q�6�   	   LocalizableHeaderText$	 @MachineOverview.Text81��6�   

 � Tag
 6�   1  +VisiWin.Extensions.VariableBindingExtension     VariableName$[ UCPU2.PLC.Blocks.04 Tray handling.07 CZ.01.02 Cooling.DB CZ 1 Cooling HMI.Actual.State��.��5      � $��10,20,10,10q�6   .+�5        VisiWin.Controls.Gauge  $	��125��6'   $	��125��63   $��9(�6@     RealisticGaugeStyle_2#���  6M   $
��Left=�6}   $��Center=�6�   $  VisiWin.Controls.NumericVarOut   LocalizableUnitText$ 
@Units.rpm��6�   *  $VisiWin.Controls.VariableBaseControl   LocalizableLabelText$ @MachineOverview.Text56��6�      RawLimitMax$
 3500Q�5         FormatString$ 0��6.      RawLimitMin$ 0Q�5         VariableName$i cCPU2.PLC.Blocks.04 Tray handling.07 CZ.01.01 Circulation.DB CZ 1 Circulation HMI.Actual.Drive.Speed��6+   +	  %VisiWin.Controls.GraphicalBaseControl 	  Limits 5   "   
  VisiWin.Controls.Limit
  5   &    
  Fill
 �  �� 
  
StartValue$
 3000Q�6:    
  EndValue$
 3500Q�6L   
  5   &   
 �/���$
 2000Q�6C   $
 3000Q�6U   
  5    &   
 � � �$ 0Q�6<   $
 2000Q�6K   5"        5#      -   5          Name$	 CZ1��5#   '   $	��150��64   $	��150��6@   $��11(�6M   $ 0��6[   $ 50Q�5$      $ 0Q�5%        RealisticGaugeStyle_1#���  5&      $��Right=�6K   $��Center=�6g   $ @Units.C��6�   $ @MachineOverview.Text22��6�   $a [CPU2.PLC.Blocks.04 Tray handling.07 CZ.01.02 Cooling.DB CZ 1 Cooling HMI.Actual.Temperature��6�    5'   "   
  5(   &   -   5        	CZ1L3��
 �  ��$ 35Q�5(   I   $ 50Q�6Y   
  5)   &   -   5        	CZ1L2��
 �/���$ 30Q�5)   R   $ 35Q�6b   
  5*   &   -   5        	CZ1L1��
 � � �$ 0Q�5*   K   $ 30Q�6Z   5,        VisiWin.Controls.Button  5-      -   5          
B_Function#���  5-   (   $	��160��6M      CornerRadius$	 100��6Z   $��
0,-5,-5,-5q�6m   $��Right=�6�   6�   5.      50      51      �� 52      $��85,0,0,0q�6   .+�53        #���  6"   $
��Left=�6F   $	��Top=�6a   $	��250��6y   $��0,5,0,0q�6�   $	 @MachineOverview.Text82��6�   
 6�     $[ UCPU2.PLC.Blocks.04 Tray handling.07 CZ.02.02 Cooling.DB CZ 2 Cooling HMI.Actual.State��.��54      � $��10,20,10,10q�6   .+�55        $	��125��6'   $	��125��63   $��9(�6@   #���  6M   $
��Left=�6}   $��Center=�6�   $ 
@Units.rpm��6�   $ @MachineOverview.Text56��6�   $
 3500Q�56      $ 0��6.   $ 0Q�57      $i cCPU2.PLC.Blocks.04 Tray handling.07 CZ.02.01 Circulation.DB CZ 2 Circulation HMI.Actual.Drive.Speed��6+    58   "   
  59   &   
 �  ��$
 3000Q�6:   $
 3500Q�6L   
  5:   &   
 �/���$
 2000Q�6C   $
 3000Q�6U   
  5;   &   
 � � �$ 0Q�6<   $
 2000Q�6K   5=        5>      -   5        $	 CZ2��5>   '   $	��150��64   $	��150��6@   $��11(�6M   $ 0��6[   $ 50Q�5?      $ 0Q�5@      #���  5A      $��Right=�6K   $��Center=�6g   $ @Units.C��6�   $ @MachineOverview.Text22��6�   $a [CPU2.PLC.Blocks.04 Tray handling.07 CZ.02.02 Cooling.DB CZ 2 Cooling HMI.Actual.Temperature��6�    5B   "   
  5C   &   -   5        	CZ2L3��
 �  ��$ 35Q�5C   I   $ 50Q�6Y   
  5D   &   -	   5        	CZ2L2��
 �/���$ 30Q�5D   R   $ 35Q�6b   
  5E   &   -
   5        	CZ2L1��
 � � �$ 0Q�5E   K   $ 30Q�6Z   5G        5H      -   5        #���  5H   (   $	��160��6M   $	 100��6Z   $��
0,-5,-5,-5q�6m   $��Right=�6�   6�   5I      5K      5M      �� 5N      $��85,0,0,0q�6   .+�5O        #���  6"   $
��Left=�6F   $	��Top=�6a   $	��250��6y   $��0,5,0,0q�6�   $	 @MachineOverview.Text83��6�   
 6�     $[ UCPU2.PLC.Blocks.04 Tray handling.07 CZ.03.02 Cooling.DB CZ 3 Cooling HMI.Actual.State��.��5P      � $��10,20,10,10q�6   .+�5Q        $	��125��6'   $	��125��63   $��9(�6@   #���  6M   $
��Left=�6}   $��Center=�6�   $ 
@Units.rpm��6�   $ @MachineOverview.Text56��6�   $
 3500Q�5R      $ 0��6.   $ 0Q�5S      $i cCPU2.PLC.Blocks.04 Tray handling.07 CZ.03.01 Circulation.DB CZ 3 Circulation HMI.Actual.Drive.Speed��6+    5T   "   
  5U   &   
 �  ��$
 3000Q�6:   $
 3500Q�6L   
  5V   &   
 �/���$
 2000Q�6C   $
 3000Q�6U   
  5W   &   
 � � �$ 0Q�6<   $
 2000Q�6K   5Y        5Z      -   5        $	 CZ3��5Z   '   $	��150��64   $	��150��6@   $��11(�6M   $ 0��6[   $ 50Q�5[      $ 0Q�5\      #���  5]      $��Right=�6K   $��Center=�6g   $ @Units.C��6�   $ @MachineOverview.Text22��6�   $a [CPU2.PLC.Blocks.04 Tray handling.07 CZ.03.02 Cooling.DB CZ 3 Cooling HMI.Actual.Temperature��6�    5^   "   
  5_   &   -   5        	CZ3L3��
 �  ��$ 35Q�5_   I   $ 50Q�6Y   
  5`   &   -   5        	CZ3L2��
 �/���$ 30Q�5`   R   $ 35Q�6b   
  5a   &   -   5        	CZ3L1��
 � � �$ 0Q�5a   K   $ 30Q�6Z   5c        5d      -   5        #���  5d   (   $	��160��6M   $	 100��6Z   $��
0,-5,-5,-5q�6m   $��Right=�6�   6�   5e      5f      5h      �� 5i      $��85,0,0,0q�6   .+�5j        #���  6"   $
��Left=�6F   $	��Top=�6a   $	��250��6y   $��0,5,0,0q�6�   $	 @MachineOverview.Text84��6�   
 6�     $[ UCPU2.PLC.Blocks.04 Tray handling.07 CZ.04.02 Cooling.DB CZ 4 Cooling HMI.Actual.State��.��5k      � $��10,20,10,10q�6   .+�5l        $	��125��6'   $	��125��63   $��9(�6@   #���  6M   $
��Left=�6}   $��Center=�6�   $ 
@Units.rpm��6�   $ @MachineOverview.Text56��6�   $
 3500Q�5m      $ 0��6.   $ 0Q�5n      $i cCPU2.PLC.Blocks.04 Tray handling.07 CZ.04.01 Circulation.DB CZ 4 Circulation HMI.Actual.Drive.Speed��6+    5o   "   
  5p   &   
 �  ��$
 3000Q�6:   $
 3500Q�6L   
  5q   &   
 �/���$
 2000Q�6C   $
 3000Q�6U   
  5r   &   
 � � �$ 0Q�6<   $
 2000Q�6K   5t        5u      -   5        $	 CZ4��5u   '   $	��150��64   $	��150��6@   $��11(�6M   $ 0��6[   $ 50Q�5v      $ 0Q�5w      #���  5x      $��Right=�6K   $��Center=�6g   $ @Units.C��6�   $ @MachineOverview.Text22��6�   $a [CPU2.PLC.Blocks.04 Tray handling.07 CZ.04.02 Cooling.DB CZ 4 Cooling HMI.Actual.Temperature��6�    5y   "   
  5z   &   -   5        	CZ4L3��
 �  ��$ 35Q�5z   I   $ 50Q�6Y   
  5{   &   -   5        	CZ4L2��
 �/���$ 30Q�5{   R   $ 35Q�6b   
  5|   &   -   5        	CZ4L1��
 � � �$ 0Q�5|   K   $ 30Q�6Z   5~        5      -   5        #���  5   (   $	��160��6M   $	 100��6Z   $��
0,-5,-5,-5q�6m   $��Right=�6�   6�   5�      5�      5�      5�        5�      #���  6   $��Right=�6>   $	��Top=�6Z   $	 @MachineOverview.Text41��6r   $��	0,20,20,0q�6�   .��5�      �� $ 
Horizontal=�6   $��5,10,5,5q�66   .+�5�        -   5          Name$
 Tmin��5�   '     NVO_Main#���  65   $��85��6X   $��45��6c   $ @Units.m��6o   $M GCPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ HMI.Actual.Clock.M��6�     5�      -   5        $
 Tsec��5�   '   #���  65   $��85��6X   $��45��6c   $��5,0,0,0q�6o   $ @Units.s��6�   $M GCPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ HMI.Actual.Clock.S��6�   5�      5�        5�      #���  6   $	��189��6>   $	��114��6J   $��Right=�6X   $	��Top=�6t   $	 @MachineOverview.Text115��6�   $��
0,460,20,0q�6�      AuthorizationRight$ MachineClock��6�      AuthorizationMode$ 
Visibility=�6�   .��5�      �� $ 
Horizontal=�6   $��5,10,5,5q�66   .+�5�        VisiWin.Controls.Key   
 B_Gray#���  6   $��85��6>   $��45��6I      Text$ < < <��6U      VariableName$M GCPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ HMI.PC.Data.from.-��6k      AuthorizationRight$ MachineClock��6�      AuthorizationMode$ 
Visibility=�6�      KeyMode$ KeyMode=�6    5�      #���  6   $��85��6>   $��45��6I   $��5,0,0,0q�6U   $ > > >��6g   $M GCPU2.PLC.Blocks.04 Tray handling.07 CZ.00 Main.DB CZ HMI.PC.Data.from.+��6}   $ MachineClock��6�   $ 
Visibility=�6�   $ KeyMode=�6  5�      5�      0   *HMI.Resources.UserControls.MO.M_WorkMode_L  5�      $��Right=�6   $��Bottom=�6:   $��	0,0,10,10q�6U       Header$  @MachineOverview.Text19��5�      !   	Automatic$d! ^CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.from.Operating mode.Automatic��5�      "   Manual$a" [CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.from.Operating mode.Manual��5�      #   SetUp$`# ZCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.from.Operating mode.Setup��5�      $   Start$[$ UCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.from.Automatic.Start��5�      %   Stop$Z% TCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.from.Automatic.Stop��5�      &   StartStatus$Y& SCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.to.Automatic.State��5�      '   WorkingModeStatus$^' XCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.to.Operating mode.State��5�      � 5�      -   5        $  Trays��5�      5�      5�      � 5�   
     FP_Blue_Gradient#���  6    5�        5�      $ White��6#   $	 270Q�61   $	 0.7Q�6A   .+�5�         VisiWin.Controls.TextBlock  -   5        (  Name$( header��5�      )   LocalizableText$) @MachineOverview.Text76��6+   $��Center=�6U   
�������$
��Bold"�6�   $��48(�6�   $��50,0,0,0q�6�   5�        5�   
   $��70��6   $	��200��6    $��Right=�6,   $��SemiBold"�6H   $��20(�6^     B_Gray2#���  6l   * �� 	IsDefault* . {�.  + J� Opacity$+ 1Q�6%  $��0,0,20,0q�62  
 6�     $Q KCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.to.Mode.State��,   LocalizableText, 6D    $Q KCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.to.Mode.State�� 	 ValueToStateTextConverter-   	Converter#- [	  
 Mode.   States#. [
 /   	StateMode$/ Value=�5�      5�      