   M S B A M L   `   `   `  ����W  S251252-Raymond-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=6505eeda710e1f37M+clr-namespace:HMI.Resources.UserControls.MOHMI.Resources.UserControls.MO  5      #    HMI.MainRegion.MO.Views.MO_HZ   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5      6UC+clr-namespace:HMI.Resources.UserControls.MO   5         FP_Black_Gradient#���   5      $
��1832��66   $
��1000��6C   .��5      � -   5          �Name$  
LayoutRoot��5       � RowDefinitions 5	   
   �� 5
      $	��110 �6   �� 5      $��* �6   .+�5   
   � $��1��6   .+�5      !  VisiWin.Controls.PictureBox     SymbolResourceKey$	 BHZ��6   $	��408��66   $	��517��6B   $
��Left=�6O   $��Bottom=�6j   $��
380,0,0,20q�6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$	 Red��6'      
BlurRadius$ 30Q�63      	Direction$ 90Q�6D      Opacity$	 0.8Q�6T   5        5      $	 BHZ��6   $	��408��66   $	��517��6B   $��Right=�6O   $��Bottom=�6k   $��
0,0,380,20q�6�    5        5      $	 Red��6'   $ 30Q�63   $ 90Q�6D   $	 0.8Q�6T   5      � 5      -   5        $  Trays��5      5        VisiWin.Controls.GroupBox  5!        	GB_Group2#���  6   $
��Left=�6>   $��Bottom=�6Y      LocalizableHeaderText$ @MachineOverview.Text114��6t   $��	20,0,0,20q�6�   .��5"      �� 	 �� Orientation$	 
Horizontal=�6   $��5,10,5,5q�66   .+�5#      $  VisiWin.Controls.NumericVarOut  -   5        
  Name$

 Tmin��5#   '     NVO_Main#���  65   $��85��6X   $��45��6c      LocalizableUnitText$ @Units.m��6o   *  $VisiWin.Controls.VariableBaseControl   VariableName$M GCPU2.PLC.Blocks.04 Tray handling.06 HZ.00 Main.DB HZ HMI.Actual.Clock.M��6�     5$      -   5        $

 Tsec��5$   '   #���  65   $��85��6X   $��45��6c   $��5,0,0,0q�6o   $ @Units.s��6�   $M GCPU2.PLC.Blocks.04 Tray handling.06 HZ.00 Main.DB HZ HMI.Actual.Clock.S��6�   5%      5&        5'      #���  6   $	��189��6>   $	��114��6J   $��Right=�6X   $	��Top=�6t   $ @MachineOverview.Text115��6�   $��0,435,1623,0q�6�      AuthorizationRight$ MachineClock��6�      AuthorizationMode$ 
Visibility=�6�   .��5(      �� $	 
Horizontal=�6   $��5,10,5,5q�66   .+�5)        VisiWin.Controls.Key   
 B_Gray#���  6   $��85��6>   $��45��6I     VisiWin.Controls.Button   Text$ < < <��6U      VariableName$M GCPU2.PLC.Blocks.04 Tray handling.06 HZ.00 Main.DB HZ HMI.PC.Data.from.-��6k      AuthorizationRight$ MachineClock��6�      AuthorizationMode$ 
Visibility=�6�      KeyMode$ KeyMode=�6    5*      #���  6   $��85��6>   $��45��6I   $��5,0,0,0q�6U   $ > > >��6f   $M GCPU2.PLC.Blocks.04 Tray handling.06 HZ.00 Main.DB HZ HMI.PC.Data.from.+��6|   $ MachineClock��6�   $ 
Visibility=�6�   $ KeyMode=�6  5+      5,      0   *HMI.Resources.UserControls.MO.M_WorkMode_L  5.      $��Right=�6   $��Bottom=�6:   $��	0,0,10,10q�6U      Header$ @MachineOverview.Text19��5/         	Automatic$d ^CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.from.Operating mode.Automatic��50         Manual$a [CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.from.Operating mode.Manual��51         SetUp$` ZCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.from.Operating mode.Setup��52         Start$[ UCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.from.Automatic.Start��53         Stop$Z TCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.from.Automatic.Stop��54         StartStatus$Y SCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.to.Automatic.State��55         WorkingModeStatus$^ XCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.to.Operating mode.State��56        58      #���  6   $
��Left=�6>   $	��Top=�6Y   $	��315��6�   $��
425,44,0,0q�6�   $ @MachineOverview.Text75��6  
 � Tag 6q   1	  +VisiWin.Extensions.VariableBindingExtension	   	  VariableName$[ UCPU2.PLC.Blocks.04 Tray handling.06 HZ.01.03 Heating.DB HZ 1 Heating HMI.Actual.State��.��59      � $��10,20,10,10q�6   .+�5:      
  VisiWin.Controls.Gauge
  $	��150��6   $	��150��6+   $��9(�68     RealisticGaugeStyle_2#���  6E   $
��Left=�6u   $��Center=�6�   $ 
@Units.rpm��6�      LocalizableLabelText$ @MachineOverview.Text56��6�      RawLimitMax$
 3500Q�5;          RawLimitMin$  0Q�6.   !   FormatString$! 0��6>   $i cCPU2.PLC.Blocks.04 Tray handling.06 HZ.01.01 Circulation.DB HZ 1 Circulation HMI.Actual.Drive.Speed��5<      +  %VisiWin.Controls.GraphicalBaseControl"   Limits" 5=        VisiWin.Controls.Limit  5>      #   Fill
# �  ��$   
StartValue$
$ 2950Q�62   %   EndValue$
% 3500Q�6D     5?      
# �/���$
$ 2000Q�6;   $
% 2950Q�6M     5@      
# � � �$$ 0Q�64   $
% 2000Q�6C   5B      
  5C      -   5        & 
 Name$	& HZ1��5C      $	��200��6,   $	��200��68   $��11(�6E   $	 365Q�5D      $  0Q�6-   $! 0��6=     RealisticGaugeStyle_1#���  5E      $��Right=�6K   $��Center=�6g   $ @Units.C��6�   $ @MachineOverview.Text22��6�   $a [CPU2.PLC.Blocks.04 Tray handling.06 HZ.01.03 Heating.DB HZ 1 Heating HMI.Actual.Temperature��5F      " 5G        5H      -   5        	HZ1L3��
# �  ��$	$ 335Q�5H   A   $	% 350Q�6R     5I      -   5        	HZ1L2��
# �/���$	$ 320Q�5I   J   $	% 335Q�6[     5J      -   5        	HZ1L1��
# � � �$$ 0Q�5J   C   $	% 320Q�6R   5L        5M      -	   5          
B_Function#���  5M       $	��210��6E   '   CornerRadius$	' 100��6R   $��
0,-5,-5,-5q�6e   $��Right=�6y   6�   5N      5O      '  !VisiWin.Controls.NavigationButton  5P      -
   5        (  Name$( V1��5P   "   $��790,228,0,0q�6.   $	��100��6C   $	��100��6O   $
��Left=�6\    	 B_Fan#���  6w   $	��Top=�6  )   ViewName$) 	MO_HZ1_EF��6-  *   
RegionName$* DialogRegion1��6B  + J� RenderTransformOrigin$+ -3.55,-2.55&�6]   6�   	  $[ UCPU2.PLC.Blocks.04 Tray handling.06 HZ.01.02 Exhaust.DB HZ 1 Exhaust HMI.Actual.State��6]    5R      #���  6   $��Right=�6>   $	��Top=�6Z   $	��315��6�   $��
0,44,425,0q�6�   $ @MachineOverview.Text112��6   6r   	  $[ UCPU2.PLC.Blocks.04 Tray handling.06 HZ.02.03 Heating.DB HZ 2 Heating HMI.Actual.State��.��5S      � $��10,20,10,10q�6   .+�5T      
  $	��150��6   $	��150��6+   $��9(�68   #���  6E   $
��Left=�6u   $��Center=�6�   $ 
@Units.rpm��6�   $ @MachineOverview.Text56��6�   $
 3500Q�5U      $  0Q�6.   $! 0��6>   $i cCPU2.PLC.Blocks.04 Tray handling.06 HZ.02.01 Circulation.DB HZ 2 Circulation HMI.Actual.Drive.Speed��5V      " 5W        5X      
# �  ��$
$ 2950Q�62   $
% 3500Q�6D     5Y      
# �/���$
$ 2000Q�6;   $
% 2950Q�6M     5Z      
# � � �$$ 0Q�64   $
% 2000Q�6C   5\      
  5]      -   5        $	& HZ2��5]      $	��200��6,   $	��200��68   $��11(�6E   $	 365Q�5^      $  0Q�6-   $! 0��6=   #���  5_      $��Right=�6K   $��Center=�6g   $ @Units.C��6�   $ @MachineOverview.Text22��6�   $a [CPU2.PLC.Blocks.04 Tray handling.06 HZ.02.03 Heating.DB HZ 2 Heating HMI.Actual.Temperature��5`      " 5a        5b      -   5        	HZ2L3��
# �  ��$	$ 335Q�5b   A   $	% 350Q�6R     5c      -   5        	HZ2L2��
# �/���$	$ 320Q�5c   J   $	% 335Q�6[     5d      -   5        	HZ2L1��
# � � �$$ 0Q�5d   C   $	% 320Q�6R   5f        5g      -   5        #���  5g       $	��210��6E   $	' 100��6R   $��
0,-5,-5,-5q�6e   $��Right=�6y   6�   5h      5i        5j      $��0,228,790,0q�6"   $	��100��67   $	��100��6C   $��Right=�6P   #���  6l   $	��Top=�6
  $) 	MO_HZ2_EF��6"  $* DialogRegion1��67  $+ -3.55,-2.55&�6R   6�   	  $[ UCPU2.PLC.Blocks.04 Tray handling.06 HZ.02.02 Exhaust.DB HZ 2 Exhaust HMI.Actual.State��6R  5l      � 5m   
     FP_Blue_Gradient#���  6    5n        5o      $ White��6#   $	 270Q�61   $	 0.7Q�6A   .+�5q         VisiWin.Controls.TextBlock  -   5        ,  Name$, header��5q      -   LocalizableText$- @MachineOverview.Text74��6+   $��Center=�6U   
�������$
��Bold"�6�   $��48(�6�   $��50,0,0,0q�6�   5r        5s   
   $��70��6   $	��200��6    $��Right=�6,   $��SemiBold"�6H   $��20(�6^    	 B_Gray2#��� 	 6l   . �� 	IsDefault. . {�.  / J� Opacity$/ 1Q�6%  $��0,0,20,0q�62   6�   	  $Q KCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.to.Mode.State��0   LocalizableText0 6D  	  $Q KCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.to.Mode.State�� 
 ValueToStateTextConverter1 	  	Converter#1 [
   Mode2 	  States#2 [ 3 	  	StateMode$3 Value=�5u      5v      