   M S B A M L   `   `   `  ����W  S251252-Raymond-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=6505eeda710e1f37M+clr-namespace:HMI.Resources.UserControls.MOHMI.Resources.UserControls.MO  5          HMI.MainRegion.MO.MO_PZWZ   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5      6UC+clr-namespace:HMI.Resources.UserControls.MO   5         FP_Black_Gradient#���   5      $
��1832��66   $
��1000��6C   .��5	      � -   5          �Name$  
LayoutRoot��5	       � RowDefinitions 5
   
   �� 5      $	��110 �6   �� 5      $��* �6   .+�5   
   � $��1��6   .+�5      !  VisiWin.Controls.PictureBox     SymbolResourceKey$ BMCTO��6   $
��1548��67   $��Center=�6E   $��Center=�6b    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ Orange��6'      
BlurRadius$ 30Q�66      	Direction$ 90Q�6G      Opacity$	 0.8Q�6W   5      .   (HMI.Resources.UserControls.MO.PZWZBasket  5      $
��Left=�6   $	��Top=�67   $��195,200,0,0q�6O      IsBasket$Q KCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Baskets.Available��5      	   
IsMaterial$P	 JCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Charge.Available��5      
   SetLayer$P
 JCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Charge.Layer.Set��5         ActualLayer$S MCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Charge.Layer.Actual��5      
   CPU$
 CPU1��5      	   AS$	 Set��6)     5      $
��Left=�6   $	��Top=�67   $��195,265,0,0q�6O   $Q KCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Baskets.Available��5      $P	 JCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Charge.Available��5      $P
 JCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Charge.Layer.Set��5       $S MCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Charge.Layer.Actual��5!         IsDischarge$[ UCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Baskets.Functions.Discharge��5"         IsWatch$W QCPU1.PLC.Blocks.02 Basket handling.04 BT.00 Main.DB BT PD.Baskets.Functions.Watch��5#      $
 CPU1��5$         Station$ 4��6(   $ Actual��64     VisiWin.Controls.Button  5'      -   5          
B_Material#���  5'   .   $��190,195,0,0q�6S   $
��Left=�6h   $	��Top=�6�   $��95��6�   $	��185��6�   .   (HMI.Resources.UserControls.MO.MVMaterial  5)      $
��Left=�6   $	��Top=�67   $��286,296,0,0q�6O   $	��435��6d   $��60��6p      
IsMaterial$N HCPU2.PLC.Blocks.04 Tray handling.01 MC.00 Main.DB MC PD.Charge.Available��5*         SetLayer$N HCPU2.PLC.Blocks.04 Tray handling.01 MC.00 Main.DB MC PD.Charge.Layer.Set��5+         ActualLayer$Q KCPU2.PLC.Blocks.04 Tray handling.01 MC.00 Main.DB MC PD.Charge.Layer.Actual��5,      
   CPU$
 CPU2��5-      	   AS$	 Set��6(     5.      $
��Left=�6   $	��Top=�67   $��286,363,0,0q�6O   $	��435��6d   $��60��6p   $N HCPU2.PLC.Blocks.04 Tray handling.01 MC.00 Main.DB MC PD.Charge.Available��5/      $N HCPU2.PLC.Blocks.04 Tray handling.01 MC.00 Main.DB MC PD.Charge.Layer.Set��50      $Q KCPU2.PLC.Blocks.04 Tray handling.01 MC.00 Main.DB MC PD.Charge.Layer.Actual��51      $
 CPU2��52      $ Actual��6(     54      -   5        #���  54   0   $��281,291,0,0q�6U   $
��Left=�6j   $	��Top=�6�   $	��445��6�   $	��135��6�     VisiWin.Controls.GroupBox  56        	GB_Group2#���  6   $��Right=�6>   $	��Top=�6Z   $	��315��6�   $��
0,20,600,0q�6�      LocalizableHeaderText$ @MachineOverview.Text67��6  
 � Tag 6r   1  +VisiWin.Extensions.VariableBindingExtension     VariableName$V PCPU2.PLC.Blocks.04 Tray handling.02 PZ.03 Heating.DB PZ Heating HMI.Actual.State��.��57      � $��10,20,10,10q�6   .+�58        VisiWin.Controls.Gauge  $	��150��6   $	��150��6+   $��9(�68     RealisticGaugeStyle_2#���  6E   $
��Left=�6u   $��Center=�6�   $	  VisiWin.Controls.NumericVarOut 	  LocalizableUnitText$ 
@Units.rpm��6�   *
  $VisiWin.Controls.VariableBaseControl 
  LocalizableLabelText$ @MachineOverview.Text56��6�    	  RawLimitMin$ 0Q�59       	  RawLimitMax$
 3800Q�6-    	  FormatString$ 0��6@    
  VariableName$d ^CPU2.PLC.Blocks.04 Tray handling.02 PZ.01 Circulation.DB PZ Circulation HMI.Actual.Drive.Speed��5:      +  %VisiWin.Controls.GraphicalBaseControl   Limits 5;        VisiWin.Controls.Limit  5<          Fill
  �  ��!   
StartValue$
! 3350Q�62   "   EndValue$
" 3800Q�6D     5=      
  �/���$
! 2500Q�6;   $
" 3350Q�6M     5>      
  � � �$! 0Q�64   $
" 2500Q�6C   5@        5A      -   5        #  Name$# PZ��5A      $	��200��6+   $	��200��67   $��11(�6D   $	 130Q�5B      $ 0Q�6-   $ 0��6=     RealisticGaugeStyle_1#���  5C      $��Right=�6K   $��Center=�6g   $ @Units.C��6�   $ @MachineOverview.Text22��6�   $\ VCPU2.PLC.Blocks.04 Tray handling.02 PZ.03 Heating.DB PZ Heating HMI.Actual.Temperature��6�    5D        5E      -   5        PZL3��
  �  ��$	! 105Q�5E   @   $	" 130Q�6Q     5F      -   5        PZL2��
  �/���$! 90Q�5F   I   $	" 105Q�6Y     5G      -   5        PZL1��
  � � �$! 0Q�5G   B   $" 90Q�6Q   5I        5J      -   5          
B_Function#���  5J       $	��210��6E   $   CornerRadius$	$ 100��6R   $��
0,-5,-5,-5q�6e   $��Right=�6y   6�   5K      5M        5O      #���  6   $��Right=�6>   $	��Top=�6Z   $	��315��6�   $��
0,20,150,0q�6�   $ @MachineOverview.Text68��6   6r     $V PCPU2.PLC.Blocks.04 Tray handling.05 WZ.03 Heating.DB WZ Heating HMI.Actual.State��.��5P      � $��10,20,10,10q�6   .+�5Q        $	��150��6   $	��150��6+   $��9(�68   #���  6E   $
��Left=�6u   $��Center=�6�   $ 
@Units.rpm��6�   $ @MachineOverview.Text56��6�   $
 2000Q�5R      $ 0Q�60   $ 0��6@   $d ^CPU2.PLC.Blocks.04 Tray handling.05 WZ.01 Circulation.DB WZ Circulation HMI.Actual.Drive.Speed��5S       5T        5U      
  �  ��$
! 1550Q�62   $
" 2000Q�6D     5V      
  �/���$
! 1000Q�6;   $
" 1550Q�6M     5W      
  � � �$! 0Q�64   $
" 1000Q�6C   5Y        5Z      -	   5        $# WZ��5Z      $	��200��6,   $	��200��68   $��11(�6E   $	 350Q�5[      $ 0Q�6/   $ 0��6?   #���  5\      $��Right=�6M   $��Center=�6i   $ @Units.C��6�   $ @MachineOverview.Text22��6�   $\ VCPU2.PLC.Blocks.04 Tray handling.05 WZ.03 Heating.DB WZ Heating HMI.Actual.Temperature��5]       5^        5_      -
   5        WZL3��
  �  ��$	! 335Q�5_   @   $	" 350Q�6Q     5`      -   5        WZL2��
  �/���$	! 320Q�5`   I   $	" 335Q�6Z     5a      -   5        WZL1��
  � � �$! 0Q�5a   B   $	" 320Q�6Q   5c        5d      -   5        #���  5d       $	��210��6E   $	$ 100��6R   $��
0,-5,-5,-5q�6e   $��Right=�6y   6�   5e      5g      0   *HMI.Resources.UserControls.MO.M_WorkMode_L  5i      $��Right=�6   $��Bottom=�6:   $��	0,0,10,10q�6U   %   Header$% @MachineOverview.Text19��5j      &   	Automatic$d& ^CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.from.Operating mode.Automatic��5k      '   Manual$a' [CPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.from.Operating mode.Manual��5l      (   SetUp$`( ZCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.from.Operating mode.Setup��5m      )   Start$[) UCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.from.Automatic.Start��5n      *   Stop$Z* TCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.from.Automatic.Stop��5o      +   StartStatus$Y+ SCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.to.Automatic.State��5p      ,   WorkingModeStatus$^, XCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Tray handling.to.Operating mode.State��5q      � 5t      -   5        $  Trays��5t      5v        5x      #���  6   $
��Left=�6>   $��Bottom=�6Y   $ @MachineOverview.Text80��6t   $��	20,0,0,20q�6�   .��5y      �� - �� Orientation$- 
Horizontal=�6   $��5,10,5,5q�66   .+�5z      	    NVO_Main#���  6'   $��85��6J   $��45��6U   $ @Units.m��6a   $M GCPU2.PLC.Blocks.04 Tray handling.01 MC.00 Main.DB MC HMI.Actual.Clock.M��6�   	  5{      #���  6'   $��85��6J   $��45��6U   $��5,0,0,0q�6a   $ @Units.s��6r   $M GCPU2.PLC.Blocks.04 Tray handling.01 MC.00 Main.DB MC HMI.Actual.Clock.S��6�   5|      5}        5~      #���  6   $
��Left=�6>   $��Bottom=�6Y   $ @MachineOverview.Text111��6t   $��
250,0,0,20q�6�   .��5      �� $- 
Horizontal=�6   $��5,10,5,5q�66   .+�5�      	  #���  6'   $��85��6J   $��45��6U   $ @Units.m��6a   $M GCPU2.PLC.Blocks.04 Tray handling.02 PZ.00 Main.DB PZ HMI.Actual.Clock.M��6�   	  5�      #���  6'   $��85��6J   $��45��6U   $��5,0,0,0q�6a   $ @Units.s��6r   $M GCPU2.PLC.Blocks.04 Tray handling.02 PZ.00 Main.DB PZ HMI.Actual.Clock.S��6�   5�      5�        5�      #���  6   $	��189��6>   $	��114��6J   $��Right=�6X   $	��Top=�6t   $ @MachineOverview.Text115��6�   $��0,756,1157,0q�6�   .   AuthorizationRight$. MachineClock��6�   /   AuthorizationMode$/ 
Visibility=�6�   .��5�      �� $- 
Horizontal=�6   $��5,10,5,5q�66   .+�5�        VisiWin.Controls.Key   
 B_Gray#���  6   $��85��6>   $��45��6I   0   Text$0 < < <��6U   1   VariableName$M1 GCPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO HMI.PC.Data.from.-��6k   2   AuthorizationRight$2 MachineClock��6�   3   AuthorizationMode$3 
Visibility=�6�   4   KeyMode$4 KeyMode=�6    5�      #���  6   $��85��6>   $��45��6I   $��5,0,0,0q�6U   $0 > > >��6f   $M1 GCPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO HMI.PC.Data.from.+��6|   $2 MachineClock��6�   $3 
Visibility=�6�   $4 KeyMode=�6  5�      5�      5�      '  !VisiWin.Controls.NavigationButton  5�   
   -   5        5  Name$5 V1��5�      $��
775,0,0,20q�6*   $	��100��6>   $	��100��6J   $
��Left=�6W    	 B_Fan#���  6r   $��Bottom=�6  6   ViewName$6 MO_PZ_EF��6&  7   
RegionName$7 DialogRegion1��6:  $��1��6U   6�     $V PCPU2.PLC.Blocks.04 Tray handling.02 PZ.02 Exhaust.DB PZ Exhaust HMI.Actual.State��6U    5�   
   -   5        $5 V2��5�      $��1255,0,0,20q�6*   $	��100��6?   $	��100��6K   $
��Left=�6X   #���  6s   $��Bottom=�6  $6 MO_WZ_EF��6'  $7 DialogRegion1��6;  $��1��6V   6�     $V PCPU2.PLC.Blocks.04 Tray handling.05 WZ.02 Exhaust.DB WZ Exhaust HMI.Actual.State��6V  �� 5�   
   	8 �� X1$8 0��6   	9 �� Y1$9 0��6   	: �� X2$: 0��6   	; �� Y2$	; 400��6%   $��1034,418,0,0q�6.    
	 FP_Red#��� 	 6D   $��5��6f   $
��Left=�6z   $	��Top=�6�   $	��260��6�   $��1��6�   � 5�   
    
 FP_Blue_Gradient#��� 
 6    5�        5�      $ White��6#   $	 270Q�61   $	 0.7Q�6A   .+�5�         VisiWin.Controls.TextBlock  -   5        <  Name$< header��5�      =   LocalizableText$= @MachineOverview.Text63��6+   $��Center=�6U   
�������$
��Bold"�6�   $��48(�6�   $��50,0,0,0q�6�   5�        5�   
   $��70��6   $	��200��6    $��Right=�6,   $��SemiBold"�6H   $��20(�6^     B_Gray2#���  6l   > �� 	IsDefault> . {�.  ? J� Opacity$? 1Q�6%  $��0,0,20,0q�62   6�     $Q KCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.to.Mode.State��@   LocalizableText@ 6D    $Q KCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.to.Mode.State��  ValueToStateTextConverterA   	Converter#A [   ModeB   States#B [ C   	StateMode$C Value=�5�      5�      