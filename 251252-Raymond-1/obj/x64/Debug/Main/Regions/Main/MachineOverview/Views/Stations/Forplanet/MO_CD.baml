   M S B A M L   `   `   `  ����W  S251252-Raymond-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=6505eeda710e1f37M+clr-namespace:HMI.Resources.UserControls.MOHMI.Resources.UserControls.MO  5      #    HMI.MainRegion.MO.Views.MO_CD   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5      6UC+clr-namespace:HMI.Resources.UserControls.MO   5         FP_Black_Gradient#���   5      $
��1832��66   $
��1000��6C   .��5	      � -   5          �Name$  
LayoutRoot��5	       � RowDefinitions 5
   
   �� 5      $	��110 �6   �� 5      $��* �6   .+�5   
   � $��1��6   .+�5      !  VisiWin.Controls.PictureBox     SymbolResourceKey$	 BCD��6   $	��781��65   $	��826��6A   $��Center=�6N   $��Center=�6k    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ 	LightBlue��6'      
BlurRadius$ 30Q�69      	Direction$ 90Q�6J      Opacity$	 0.8Q�6Z   5      ,   &HMI.Resources.UserControls.MO.CDBasket  5      $
��Left=�6   $	��Top=�65   $��767,412,0,0q�6M      IsBasket$P JCPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Baskets.Available��5      	   
IsMaterial$O	 ICPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Charge.Available��5      
   SetLayer$O
 ICPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Charge.Layer.Set��5         ActualLayer$R LCPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Charge.Layer.Actual��5         IsDischarge$Z TCPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Baskets.Functions.Discharge��5         IsWatch$V PCPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Baskets.Functions.Watch��5      
   CPU$
 CPU1��5         Station$ 10��6(   	   AS$	 Set��65     5      $
��Left=�6   $	��Top=�65   $��945,412,0,0q�6M   $P JCPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Baskets.Available��5       $O	 ICPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Charge.Available��5!      $O
 ICPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Charge.Layer.Set��5"      $R LCPU1.PLC.Blocks.03 Basket coating.01 CD.00 Main.DB CD PD.Charge.Layer.Actual��5#      $
 CPU1��5%      $ 10��6#   $ Actual��60     VisiWin.Controls.Button  5'      -   5          
B_Material#���  5'   0   $��760,400,0,0q�6U   $
��Left=�6j   $	��Top=�6�   $	��355��6�   $	��160��6�   � 5)      -   5        $	  LTB��5)      $
��Left=�6    $��Bottom=�6;   $��
746,0,0,34q�6V    � ColumnDefinitions 5*      �� 5+      $
��194* �6'   �� 5,      $
��183* �6'   .+�5.        $
 BCDT��6!   $	��377��6:   $	��267��6F   $��Center=�6S   $��Center=�6p   $��2��6�    5/        50      $ 	LightBlue��6+   $ 30Q�6=   $ 90Q�6N   $	 0.8Q�6^   52      !  VisiWin.Controls.TextVarOut  53      $��40��6    $��7,0,2,35q�6,     TVO_Main#���  6>   $��Bottom=�6a   $��Center=�6|   $��2��6�     Value 6�   1  +VisiWin.Extensions.VariableBindingExtension     VariableName$Q KCPU1.PLC.Blocks.03 Basket coating.02 DT.01 Lift.DB DT Lift HMI.Actual.State��  ValueToStateTextConverter   	Converter# [   TSC_DTPositions   States# [    	StateMode$ Value=�6�    54      -   5          Name$ PaintTyp��54       #���  62   $��45��6U   $��Bottom=�6a   $��Stretch=�6|   *  $VisiWin.Controls.VariableBaseControl   LocalizableLabelText$ @MachineOverview.Text27��6�   $��2��6�   $��54,0,49,160q�6�     56      $��45��6    #���  6,   $ @MachineOverview.Text26��6P   $	��Top=�6   $��Stretch=�6�   $��
54,14,49,0q�6�      VariableName$J DCPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT PD.Tank.Number��6�   $��2��6  57        VisiWin.Controls.GroupBox  58        	GB_Group2#���  6   $��Right=�6>   $	��Top=�6Z      LocalizableHeaderText$ @MachineOverview.Text106��6r   $��	0,20,20,0q�6�   .��59      ��  �� Orientation$ 
Horizontal=�6   $��5,10,5,5q�66   .+�5:      $	  VisiWin.Controls.NumericVarOut	  -   5         	 Name$
 Tmin��5:   '     NVO_Main#���  65   $��85��6X   $��45��6c    	  LocalizableUnitText$ @Units.m��6o   $J DCPU1.PLC.Blocks.03 Basket coating.00 Main.DB BC HMI.Actual.Coating.M��6�   	  5;      -   5        $
 Tsec��5;   '   #���  65   $��85��6X   $��45��6c   $��5,0,0,0q�6o   $ @Units.s��6�   $J DCPU1.PLC.Blocks.03 Basket coating.00 Main.DB BC HMI.Actual.Coating.S��6�   5<      5=      � 5?      $��Bottom=�6   $��Right=�6.   $	��760��6J   $	��515��6W   $��0,0,0,0q�6c   .+�5@      
  VisiWin.Controls.Region
  -   5         
 Name$ region��5@      $��Center=�6,   $��Center=�6G   6d   5A      � 5B      $��Center=�6   $	��Top=�60   $	��310��6H   $��	45,45,0,0q�6T   .+�5C        VisiWin.Controls.Gauge  -   5          Name$ planet��5C      $	��130��6+   $	��130��67   $��9(�6D     RealisticGaugeStyle_2#���  6Q   $
��Left=�6�   $��Center=�6�   $ @Units.grad��6�   $ @MachineOverview.Text25��6�     	  RawLimitMax$  50Q�5D      ! 	  FormatString$! 0��6,   " 	  RawLimitMin$" 0Q�5E      $Z TCPU1.PLC.Blocks.03 Basket coating.01 CD.04 Tilt.DB CD Tilt HMI.Actual.Drive.Position��6+   +  %VisiWin.Controls.GraphicalBaseControl#   Limits# 5F        VisiWin.Controls.Limit  5G      $   Fill
$ �  ��%   
StartValue$% 40Q�6.   &   EndValue$& 50Q�6>     5H      
$ � E��$% 30Q�64   $& 40Q�6D     5I      
$ � ���$% 20Q�61   $& 30Q�6A     5J      
$ �/���$% 10Q�67   $& 20Q�6G     5K      
$ � � �$% 0Q�60   $& 10Q�6?   5M        5N      -	   5        $ swing��5N      $	��130��6*   $	��130��66   $��9(�6C     RealisticGaugeStyle_3#���  6Q   $��Right=�6�   $��Center=�6�   $ 
@Units.rpm��6�   $ @MachineOverview.Text24��6�   $  10Q�5O      $! 0��6,   $	" -10Q�5P      $[ UCPU1.PLC.Blocks.03 Basket coating.01 CD.02 Planet.DB CD Planet HMI.Actual.Drive.Speed��6-   # 5Q        5R      
$ �  ��$% 8Q�6.   $& 10Q�6=     5S      
$ � E��$% 6Q�64   $& 8Q�6C     5T      
$ � ���$% 4Q�61   $& 6Q�6@     5U      
$ �/���$% 2Q�67   $& 4Q�6F     5V      
$ � � �$% 0Q�60   $& 2Q�6?     5W      
$ � � �$% -2Q�60   $& 0Q�6@     5X      
$ �/���$% -4Q�67   $& -2Q�6G     5Y      
$ � ���$% -6Q�62   $& -4Q�6B     5Z      
$ � E��$% -8Q�64   $& -6Q�6D     5[      
$ �  ��$	% -10Q�6.   $& -8Q�6?   5]        5^      -
   5        $ rotor��5^      $	��160��6*   $	��160��66   $��11(�6C   $	  220Q�5_      $! 0��6-   $" 0Q�5`       	 RealisticGaugeStyle_1#��� 	 5a      $��Center=�6K   $��Center=�6h   $ 
@Units.rpm��6�   $ @MachineOverview.Text23��6�   $Y SCPU1.PLC.Blocks.03 Basket coating.01 CD.01 Rotor.DB CD Rotor HMI.Actual.Drive.Speed��5b      # 5c        5d      
$ �  ��$	% 200Q�6.   $	& 250Q�6?     5e      
$ � E��$	% 150Q�64   $	& 200Q�6E     5f      
$ � ���$	% 100Q�61   $	& 150Q�6B     5g      
$ �/���$% 50Q�67   $	& 100Q�6G     5h      
$ � � �$% 0Q�60   $& 50Q�6?   5j      5k        5l      -   5        $ DT��5l      $	��160��6#   $	��160��6/   $��11(�6<   $��262,0,0,270q�6J   #��� 	 6`   $
��Left=�6�   $��Bottom=�6�   $ @Units.C��6�   $ @MachineOverview.Text22��6�   $  50Q�5m      $! 0��6,   $" 0Q�5n      $] WCPU1.PLC.Blocks.03 Basket coating.02 DT.03 Cooling.DB DT Cooling HMI.Actual.Temperature��6+   # 5o        5p      -   5        DTL3��
$ �  ��$% 30Q�5p   8   $& 50Q�6H     5q      -   5        DTL2��
$ �/���$% 20Q�5q   A   $& 30Q�6Q     5r      -   5        DTL1��
$ � � �$% 0Q�5r   :   $& 20Q�6I   5t        5u      -   5         
 
B_Function#��� 
 5u      $	��180��6=   $	��180��6I   $��11(�6V   '   CornerRadius$	' 100��6d   $��252,0,0,260q�6w   $
��Left=�6�   $��Bottom=�6�   6�   '  !VisiWin.Controls.NavigationButton  5v      -   5        (  Name$( V1��5v   "   $��
526,80,0,0q�6.   $	��100��6B   $	��100��6N   $
��Left=�6[    	 B_Fan#���  6v   $	��Top=�6  )   ViewName$) MO_Coating_EF��6(  *   
RegionName$* DialogRegion1��6A  
+ � Tag+ 6�     $W QCPU1.PLC.Blocks.03 Basket coating.01 CD.08 Exhaust.DB CD Exhaust HMI.Actual.State��6A    5w      -   5        $( V2��5w   "   $��1226,80,0,0q�6.   $	��100��6C   $	��100��6O   $
��Left=�6\   #���  6w   $	��Top=�6  $) MO_Coating_SF��6(  $* DialogRegion1��6A  + 6�     $U OCPU1.PLC.Blocks.03 Basket coating.01 CD.07 Supply.DB CD Supply HMI.Actual.State��6A  0   *HMI.Resources.UserControls.MO.M_WorkMode_R  5y      $
��Left=�6   $��Bottom=�69   $��	20,0,0,10q�6T   ,   Header$, @MachineOverview.Text18��5z      -   	Automatic$e- _CPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket coating.from.Operating mode.Automatic��5{      .   Manual$b. \CPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket coating.from.Operating mode.Manual��5|      /   SetUp$a/ [CPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket coating.from.Operating mode.Setup��5}      0   Start$\0 VCPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket coating.from.Automatic.Start��5~      1   Stop$[1 UCPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket coating.from.Automatic.Stop��5      2   StartStatus$Z2 TCPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket coating.to.Automatic.State��5�      3   WorkingModeStatus$_3 YCPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket coating.to.Operating mode.State��5�        5�      -   5        $	��160��5�      $��90��6$   $
��Left=�60   $	��Top=�6K   $��259,280,0,0q�6c    
 B_Gray#���  6y   4   LocalizableText$4 @MachineOverview.Text30��6�   6�     5�      -   5        5  Name$5 vgroup��5�        GB_Group#���  6*   $ @MachineOverview.Text51��6M   $
��Left=�6}   $	��Top=�6�   $��	20,20,0,0q�6�   .��5�      �� $ 
Horizontal=�6   $��10q�66   .+�5�      	  #���  6'   $��90��6J   $��60��6U   $��0,0,0,0q�6a   $ @Units.h��6s   $R LCPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Actual.Viscosity.H��6�   	  5�      #���  6'   $��90��6J   $��60��6U   $��10,0,0,0q�6a   $ @Units.m��6s   $R LCPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Actual.Viscosity.M��6�   	  5�      #���  6'   $��90��6J   $��60��6U   $��10,0,0,0q�6a   $ @Units.s��6s   $R LCPU1.PLC.Blocks.03 Basket coating.02 DT.00 Main.DB DT HMI.Actual.Viscosity.S��6�     5�      -   5        $	��160��5�       $��80��6,   $��Center=�68   $��Bottom=�6U   $��10,0,0,0q�6p     	B_Gray_ns#���  6�   $4 @MachineOverview.Text50��6�   6�   5�      5�      5�      � 5�   
     FP_Blue_Gradient#���  6    5�        5�      $ White��6#   $	 270Q�61   $	 0.7Q�6A   .+�5�         VisiWin.Controls.TextBlock  -   5        6  Name$6 header��5�      7   LocalizableText$7 @MachineOverview.Text18��6+   $��Center=�6U   
�������$
��Bold"�6�   $��48(�6�   $��50,0,0,0q�6�   5�        5�   
   $��70��6   $	��200��6    $��Right=�6,   $��SemiBold"�6H   $��20(�6^     B_Gray2#���  6l   8 �� 	IsDefault8 . {�.  9 J� Opacity$9 1Q�6%  $��0,0,20,0q�62  + 6�     $Q KCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.to.Mode.State��4 6D    $Q KCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.to.Mode.State��# [   Mode# [ $ Value=�5�      5�      