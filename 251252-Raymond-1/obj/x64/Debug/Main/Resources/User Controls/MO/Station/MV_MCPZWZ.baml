   M S B A M L   `   `   `  ����W  S251252-Raymond-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=6505eeda710e1f37M+clr-namespace:HMI.Resources.UserControls.MOHMI.Resources.UserControls.MO  5      -    'HMI.Resources.UserControls.MO.MV_MCPZWZ   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5      6UC+clr-namespace:HMI.Resources.UserControls.MO   5      -   5          J� Opacity$  0Q�5   E   .��5      � -   5         �Name$ A��5      .+�5   
   !  VisiWin.Controls.PictureBox     SymbolResourceKey$ 	MV_MCPZWZ��6   $	��895��66   $	��326��6B   $��31,3,3,3q�6P   $��Right=�6b   $	��Top=�6~    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5	         Color$ Orange��6#      
BlurRadius$ 20Q�62      	Direction$ 90Q�6C      Opacity$	 0.5Q�6S   5      .   (HMI.Resources.UserControls.MO.MVMaterial  5   
   $��
40,123,0,0q�6   $
��Left=�6,   $	��Top=�6G   $	��111��6_   $��37��6k      
IsMaterial$N HCPU2.PLC.Blocks.04 Tray handling.01 MC.00 Main.DB MC PD.Charge.Available��5      	   SetLayer$N	 HCPU2.PLC.Blocks.04 Tray handling.01 MC.00 Main.DB MC PD.Charge.Layer.Set��5      
   ActualLayer$Q
 KCPU2.PLC.Blocks.04 Tray handling.01 MC.00 Main.DB MC PD.Charge.Layer.Actual��5      
   CPU$
 CPU2��5      	   AS$	 Set��6$     5   
   $��
40,162,0,0q�6   $
��Left=�6,   $	��Top=�6G   $	��111��6_   $��37��6k   $N HCPU2.PLC.Blocks.04 Tray handling.01 MC.00 Main.DB MC PD.Charge.Available��5      $N	 HCPU2.PLC.Blocks.04 Tray handling.01 MC.00 Main.DB MC PD.Charge.Layer.Set��5      $Q
 KCPU2.PLC.Blocks.04 Tray handling.01 MC.00 Main.DB MC PD.Charge.Layer.Actual��5      $
 CPU2��5      $ Actual��6$     5   
   $ MV_PORam��6   $	��353��66   $	��155��6B   $��Bottom=�6P   $
��Left=�6k   $��0,3,11,0q�6�    5        5      $ Black��6#   $ 3Q�61   $	 270Q�6A   $	 0.5Q�6R   5      *   $HMI.Resources.UserControls.MO.MVTray  5   
   -   5          Name$ Tray1��5      $
��Left=�6#   $	��Top=�6>   $��867,130,0,0q�6V      IsTray$U OCPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[0].Tray.Available��5         IsDischarge$_ YCPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[0].Tray.Functions.Discharge��5         IsWatch$[ UCPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[0].Tray.Functions.Watch��5         
IsMaterial$W QCPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[0].Charge.Available��5          SetLayer$W QCPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[0].Charge.Layer.Set��5!         ActualLayer$Z TCPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[0].Charge.Layer.Actual��5"         Station$ 3��5#         Place$ 20��6!      Header$ @Status.Text52��6,      Type$
 Tray��6D   
   CPU$
 CPU2��6P     5$   
   $ MV_MCPZWZ_fix��6   $��13��6:   $	��189��6E   $��
865,49,0,0q�6S   $
��Left=�6g   $	��Top=�6�    5%        5&      $ Black��6#   $ 3Q�61   $ 0Q�6A   $	 0.3Q�6P   5(        VisiWin.Controls.Button  5)   
   $��55��6   $��5��6   $��0q�6*      CornerRadius$ 0��6>   ���#757575$��
57,258,0,0q�6d   $
��Left=�6x   $	��Top=�6�    5*        5+      $ Black��6#   $ 3Q�61   $	 270Q�6A   $	 0.5Q�6R   5-        5/   
   -   5        $ Tray2��5/      $
��Left=�6#   $	��Top=�6>   $��329,175,0,0q�6V   $V PCPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[10].Tray.Available��50      $` ZCPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[10].Tray.Functions.Discharge��51      $\ VCPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[10].Tray.Functions.Watch��52      $X RCPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[10].Charge.Available��53      $X RCPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[10].Charge.Layer.Set��54      $[ UCPU2.PLC.Blocks.04 Tray handling.03 TO.00 Main.DB TO PD.Place[10].Charge.Layer.Actual��55      $ 3��56      $ 20��6!   $ @Status.Text52��6,   $
 Tray��6D   $
 CPU2��6P     57   
   $ MV_MCPZWZ_fix2��6   $��75��6;   $	��226��6F   $
��Left=�6U   $	��Top=�6p   $��
322,31,0,0q�6�    58        59      $ Black��6#   $ 3Q�61   $	 270Q�6A   $	 0.4Q�6R   5;      '  !VisiWin.Controls.NavigationButton  5=   
   -   5          Name$
 ExPZ��5=      $��60��6,   $	��100��68   $��13(�6D   $��SemiBold"�6R    
  B_Gray#���   6h   $ 4��6�      LocalizableText$ @MachineOverview.Text21��6     ViewName$ MO_PZ_EF��6=     
RegionName$ DialogRegion1��6Q  $��295,-25,0,0q�6l  $	��Top=�6�  $
��Left=�6�  
 � Tag 6�   1  +VisiWin.Extensions.VariableBindingExtension     VariableName$V PCPU2.PLC.Blocks.04 Tray handling.02 PZ.02 Exhaust.DB PZ Exhaust HMI.Actual.State��6�  � 5>   
   $	��100��6   $��60��6   $	��Top=�6'   $
��Left=�6?   $��175,-25,0,0q�6Z   .+�5?        {�.  $  1Q�6+     	B_Gray_ns#���  67   $��0,5,0,0q�6[   $��13(�6m   $��SemiBold"�6{   $ @MachineOverview.Text56��6�   $	��Top=�6�    6�     $^ XCPU2.PLC.Blocks.04 Tray handling.02 PZ.01 Circulation.DB PZ Circulation HMI.Actual.State��$  VisiWin.Controls.NumericVarOut  5@      -   5           Name$	  PZF��5@      $��0,0,3,0q�6,     NVO_Main#���  6>   $��30��6a   !   LocalizableUnitText$! 
@Units.rpm��6m   "   Value$
" 2500Q�6�   *	  $VisiWin.Controls.VariableBaseControl# 	  TextAlignment$# Center=�6�   $��Bottom=�6�   $   FormatString$$ 0��6�   $��2,0,2,2q�6�   5A      � 5B   
   $	��100��6   $��60��6   $	��Top=�6'   $
��Left=�6?   $��415,-25,0,0q�6Z   .+�5C        {�.  $  1Q�6+   #���  67   $��0,5,0,0q�6[   $��13(�6m   $��SemiBold"�6{   $ @MachineOverview.Text22��6�   $	��Top=�6�    6�     $V PCPU2.PLC.Blocks.04 Tray handling.02 PZ.03 Heating.DB PZ Heating HMI.Actual.State��  5D      -   5        $	  PZT��5D      $��0,0,3,0q�6,   #���  6>   $��30��6a   $! @Units.C��6m   $	" 500Q�6�   $# Center=�6�   $��Bottom=�6�   $$ 0��6�   $��2,0,2,2q�6�   5E        5G   
   -   5        $
 ExWZ��5G      $��60��6,   $	��100��68   $��13(�6D   $��SemiBold"�6R   #���   6h   $ 4��6�   $ @MachineOverview.Text21��6  $ MO_WZ_EF��6=  $ DialogRegion1��6Q  $��650,-65,0,0q�6m  $	��Top=�6�  $
��Left=�6�   6�     $V PCPU2.PLC.Blocks.04 Tray handling.05 WZ.02 Exhaust.DB WZ Exhaust HMI.Actual.State��6�  � 5I   
   $	��100��6   $��60��6   $	��Top=�6'   $
��Left=�6?   $��530,-65,0,0q�6Z   .+�5J        {�.  $  1Q�6+   #���  67   $��0,5,0,0q�6[   $��13(�6m   $��SemiBold"�6{   $ @MachineOverview.Text56��6�   $	��Top=�6�    6�     $^ XCPU2.PLC.Blocks.04 Tray handling.05 WZ.01 Circulation.DB WZ Circulation HMI.Actual.State��  5K      -	   5        $	  WZF��5K      $��0,0,3,0q�6,   #���  6>   $��30��6a   $! 
@Units.rpm��6m   $
" 2500Q�6�   $# Center=�6�   $��Bottom=�6�   $$ 0��6�   $��2,0,2,2q�6�   5L      � 5N   
   $	��100��6   $��60��6   $	��Top=�6'   $
��Left=�6?   $��770,-65,0,0q�6Z   .+�5O        {�.  $  1Q�6+   #���  67   $��0,5,0,0q�6[   $��13(�6m   $��SemiBold"�6{   $ @MachineOverview.Text22��6�   $	��Top=�6�    6�     $V PCPU2.PLC.Blocks.04 Tray handling.05 WZ.03 Heating.DB WZ Heating HMI.Actual.State��  5P      -
   5        $	  WZT��5P      $��0,0,3,0q�6,   #���  6>   $��30��6a   $! @Units.C��6m   $	" 500Q�6�   $# Center=�6�   $��Bottom=�6�   $$ 0��6�   $��2,0,2,2q�6�   5Q        5S   
   -   5          	B_Station#���  5S   ,   $��0,40,-10,50q�6P   5V      5X      