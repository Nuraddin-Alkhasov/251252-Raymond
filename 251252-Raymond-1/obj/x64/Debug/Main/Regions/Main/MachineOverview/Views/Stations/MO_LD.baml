   M S B A M L   `   `   `  ����W  S251252-Raymond-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=6505eeda710e1f37M+clr-namespace:HMI.Resources.UserControls.MOHMI.Resources.UserControls.MO  5      #    HMI.MainRegion.MO.Views.MO_LD   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5      6UC+clr-namespace:HMI.Resources.UserControls.MO   5         FP_Black_Gradient#���   5      $
��1832��66   $
��1000��6C   .��5
      � -   5          �Name$  
LayoutRoot��5
       � RowDefinitions 5   
   �� 5      $	��110 �6   �� 5      $��* �6   .+�5   
   � $��1��6   .+�5      !  VisiWin.Controls.PictureBox     SymbolResourceKey$	 BLD��6   $
��1840��65   $	��890��6B   $��Center=�6O   $��Center=�6l    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ White��6'      
BlurRadius$ 30Q�65      	Direction$	 270Q�6F      Opacity$	 0.5Q�6W   5      .   (HMI.Resources.UserControls.MO.MVMaterial  5      $
��Left=�6   $	��Top=�67   $��1084,76,0,0q�6O   $	��260��6d   $	��130��6q      
IsMaterial$O ICPU1.PLC.Blocks.01 Basket feeding.01 LD.00 Main.DB LD PD.Charge.Available��5      
	   CPU$
	 CPU1��5      
   Type$	
 Box��6'      Station$ 1��62      Header$ @Status.Text22��6>     5      $
��Left=�6   $	��Top=�67   $��667,335,0,0q�6O   $	��132��6d   $	��358��6q   $O ICPU1.PLC.Blocks.01 Basket feeding.02 HC.00 Main.DB HC PD.Charge.Available��5      $
	 CPU1��5      $

 Belt��6'   $ 2��63   $ @Status.Text23��6?     5      $
��Left=�6   $	��Top=�67   $��615,318,0,0q�6O   $	��292��6d   $��41��6q   $O ICPU1.PLC.Blocks.01 Basket feeding.03 DC.00 Main.DB DC PD.Charge.Available��5      $
	 CPU1��5      $

 Belt��6'   $ 3��63   $ @Status.Text24��6@   ,   &HMI.Resources.UserControls.MO.LDBasket  5!      $
��Left=�6   $	��Top=�65   $��598,670,0,0q�6M      IsBasket$P JCPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Baskets.Available��5"         
IsMaterial$O ICPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Charge.Available��5#         SetLayer$O ICPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Charge.Layer.Set��5$         ActualLayer$R LCPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Charge.Layer.Actual��5%         IsDischarge$Z TCPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Baskets.Functions.Discharge��5'         IsWatch$V PCPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Baskets.Functions.Watch��5(      
   CPU$
 CPU1��5)         Station$ 4��6%   	   AS$	 Set��61     5*      $
��Left=�6   $	��Top=�65   $��698,670,0,0q�6M   $P JCPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Baskets.Available��5+      $O ICPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Charge.Available��5,      $O ICPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Charge.Layer.Set��5-      $R LCPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS PD.Charge.Layer.Actual��5.      $
 CPU1��5/      $ Actual��6%   $  VisiWin.Controls.NumericVarOut  51      $	��200��6   $��45��6+   $��Right=�67   $	��Top=�6S   $��0,551,890,0q�6k     NVO_Main#���  6�   *  $VisiWin.Controls.VariableBaseControl   LocalizableLabelText$ @MachineOverview.Text9��6�      LocalizableUnitText$ 	@Units.kg��6�      FormatString$	 0.0��6�      VariableName$T NCPU1.PLC.Blocks.01 Basket feeding.02 HC.02 Scale.DB HC Scale HMI.Actual.Weight��6    52      $	��200��6   $��45��6+   $��Right=�67   $	��Top=�6S   $��0,371,1268,0q�6k   #���  6�   $ @MachineOverview.Text10��6�   $ 	@Units.kg��6�   $	 0.0��6�   $T NCPU1.PLC.Blocks.01 Basket feeding.03 DC.02 Scale.DB DC Scale HMI.Actual.Weight��6    53      $	��200��6   $��45��6+   $��Right=�67   $	��Top=�6S   $��0,725,825,0q�6k   #���  6�   $ @MachineOverview.Text12��6�   $ 	@Units.kg��6�   $	 0.0��6�   $S MCPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS HMI.Actual.Weight.Right��6    54      $	��200��6   $��45��6+   $��Right=�67   $	��Top=�6S   $��0,725,1260,0q�6k   #���  6�   $ @MachineOverview.Text11��6�   $ 	@Units.kg��6�   $	 0.0��6�   $R LCPU1.PLC.Blocks.01 Basket feeding.04 BS.00 Main.DB BS HMI.Actual.Weight.Left��6    55      -   5          Name$ f_weight��55      $	��140��61   $��45��6=   $ @MachineOverview.Text14��6I   #���  6x   $��Right=�6�   $	��Top=�6�   $��0,828,1146,0q�6�   $ 	@Units.kg��6�   $ Main.WeightFrom��6  $	 0.0��6$    56      -   5        $ t_weight��56      $	��140��61   $��45��6=   $ @MachineOverview.Text15��6I   #���  6x   $��Right=�6�   $	��Top=�6�   $��0,828,1001,0q�6�   $ 	@Units.kg��6�   $ Main.WeightTo��6  $	 0.0��6"    VisiWin.Controls.Button  58      -   5          
B_Material#���  58   0   $��585,660,0,0q�6U   $
��Left=�6j   $	��Top=�6�   $	��225��6�   $	��170��6�   #  VisiWin.Controls.ToggleButton  59      $��
0,0,80,767q�6   $y�Hidden=�62   $��80��6F   $��80��6Q   $��Right=�6]     TB_Main#���  6y      SymbolResourceKey$
 Lamp��6�   $��Bottom=�6�   	  VisiWin.Controls.GroupBox	  5=        	GB_Group2#���  6   $��Right=�6>   $	��Top=�6Z    	  LocalizableHeaderText$ @MachineOverview.Text105��6r   $��	0,20,20,0q�6�   .��5>      ��  �� Orientation$ 
Horizontal=�6   $��5,10,5,5q�66   .+�5?        -   5        $
 Tmin��5?   '   #���  65   $��85��6X   $��45��6c   $ @Units.m��6o   $P JCPU1.PLC.Blocks.01 Basket feeding.00 Main.DB BF HMI.Actual.Feeding.LD-HC.M��6�     5@      -   5        $
 Tsec��5@   '   #���  65   $��85��6X   $��45��6c   $��5,0,0,0q�6o   $ @Units.s��6�   $P JCPU1.PLC.Blocks.01 Basket feeding.00 Main.DB BF HMI.Actual.Feeding.LD-HC.S��6�   5A      5B      0
   *HMI.Resources.UserControls.MO.M_WorkMode_R
  5D      $
��Left=�6   $	��Top=�69   $��	20,10,0,0q�6Q    
  Header$ @MachineOverview.Text8��5E       
  	Automatic$e _CPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket feeding.from.Operating mode.Automatic��5F        
  Manual$b  \CPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket feeding.from.Operating mode.Manual��5G      ! 
  SetUp$a! [CPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket feeding.from.Operating mode.Setup��5H      " 
  Start$\" VCPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket feeding.from.Automatic.Start��5I      # 
  Stop$[# UCPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket feeding.from.Automatic.Stop��5J      $ 
  StartStatus$Z$ TCPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket feeding.to.Automatic.State��5K      % 
  WorkingModeStatus$_% YCPU1.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Basket feeding.to.Operating mode.State��5L      5N      � 5P   
     FP_Blue_Gradient#���  6    5Q        5R      $ White��6#   $	 270Q�61   $	 0.7Q�6A   .+�5T         VisiWin.Controls.TextBlock  -   5        &  Name$& header��5T      '   LocalizableText$' @MachineOverview.Text8��6+   $��Center=�6T   
�������$
��Bold"�6�   $��48(�6�   $��50,0,0,0q�6�   5U        5W   
   $��70��6   $	��200��6    $��Right=�6,   $��SemiBold"�6H   $��20(�6^     B_Gray2#���  6l   ( �� 	IsDefault( . {�.  ) J� Opacity$) 1Q�6%  $��0,0,20,0q�62  
* � Tag* 6�   1  +VisiWin.Extensions.VariableBindingExtension  +   VariableName$Q+ KCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.to.Mode.State��,   LocalizableText, 6D    $Q+ KCPU2.PLC.Blocks.00 Main.02 HMI.00 Main.DB HMI Main.Production.to.Mode.State��  ValueToStateTextConverter-   	Converter#- [   Mode.   States#. [ /   	StateMode$/ Value=�5[      5]      