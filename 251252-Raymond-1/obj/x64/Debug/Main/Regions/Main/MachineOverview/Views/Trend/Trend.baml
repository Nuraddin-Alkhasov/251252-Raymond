   M S B A M L   `   `   `  ����  251252-Raymond-1#    HMI.MainRegion.MO.Views.Trend   5   
   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   
   Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5   
   <d2http://schemas.microsoft.com/expression/blend/2008   5   
   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5   
   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   
   $
��1832��5	   
   $
��1000��6      FP_Black_Gradient#��[  6%   .��5      � -   5          �Name$  
LayoutRoot��5       � RowDefinitions 5   
   �� 5      $	��110 �6   �� 5      $��* �6   .+�5   
   � $��1��6    5      �� 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      !  VisiWin.Controls.TrendChart  -   5          Name$ 
TrendChart��5      $��10q�60      VisiWin.Controls.ChartBase   IsTranslateYEnabled .  .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ Loaded��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 60   ��  �� Path$ LoadChartInstance�	 �� Mode$	 OneWay=�
   CommandParameter
 6h   %  System.Windows.Markup.Reference     Name$ 
TrendChart��5         Markers 5      "  VisiWin.Controls.ChartMarker  5          LineThickness$ 2Q�6%      
IsSelected . 67      CurvesContainers 5"      3	  -VisiWin.Controls.TrendCurvesContainerDateTime	  5#      -   5         	 Name$ DateTimeCurveContainer��5#   6   �
  �VisiWin.Controls.CurvesContainerBase2`2[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.TimeSpan, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] 
  
ScaleBrush
 ����� 
  Range 6i   ��  �� ElementName$ resolutionComboBox��$ SelectedValue�$	 TwoWay=��  �VisiWin.Controls.TrendCurvesContainerBase`2[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.TimeSpan, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   IsOnline 6�   �� *
IsOnline+   Curves 5$      "  VisiWin.Controls.TrendCurve2  5%      -   5          Name$ curve1��5%   -     FP_Blue�  �VisiWin.Controls.CurveBase2`2[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   	LineColor# �  6     LineThickness$ 2Q�6(     IsScaleVisible .     ArchiveName 6=   �� *TrendData.ArchiveName+   	TrendName 6k   �� *TrendData.TrendName_1+
 � Tag 6�   �� *TrendData.CurveTag_1+   MinValue 6�   �� *TrendData.Min+   MaxValue 6�   �� *TrendData.Max+6:    5&      -   5        $ curve2��5&   -    
 FP_Red# �  6  $ 2Q�6(     
ScaleBrush
 �����    	LineStyle$	  Dot=�6N   6=   �� *TrendData.ArchiveName+ 6k   �� *TrendData.TrendName_2+ 6�   �� *TrendData.CurveTag_2+ 6�   �� *TrendData.Min+ 6�   �� *TrendData.Max+6N  5(      5*      �� 5,      $��1��6   $��Center=�6&   $��Stretch=�6C   ! �� Orientation$! 
Horizontal=�6_   $��10q�6x   .+�5-        VisiWin.Controls.ComboBox  -   5        "  Name$" resolutionComboBox��5-        CB_Main#���  6:   #   LocalizableLabelText$# @TrendSystem.Text17��6\   $	��Top=�6�   $	��250��6�   $��45��6�   $��0,0,1,0q�6�   $ �� SelectedIndex$$ 0��6�   ��6�   �� *Resolutions+6�   #  VisiWin.Controls.NumericVarIn  5.      -   5        %  Name$	% min��5.   "   $��5,0,0,0q�6/   $��45��6@   $	��120��6L     NVI_Main#���  6X   *  $VisiWin.Controls.VariableBaseControl&   LocalizableLabelText$& @TrendSystem.Text8��6{   '   VariableName$' 	Trend.Min��6�   (   RawLimitMin$
( -100Q�6�   )   RawLimitMax$	) 500Q�6�   *   LocalizableUnitText$* @Units.C��6�     5/      -   5        $	% max��5/   "   $��5,0,0,0q�6/   $��45��6@   $	��120��6L   #���  6X   $& @TrendSystem.Text9��6{   $' 	Trend.Max��6�   $
( -100Q�6�   $	) 500Q�6�   $* @Units.C��6�     VisiWin.Controls.Button  51       
 B_Gray#���  6   +   Text$+ <<��6=   $��45��6M   $	��150��6Y   $��40,0,0,0q�6e   $
��-0.7��6�   ��6w   �� *ShiftXCommand+$ 
TrendChart��6�     52      #���  6   $+ <��6=   $��45��6I   $	��150��6U   $��10,0,0,0q�6a   $
��-0.1��6�   ��6s   �� *ShiftXCommand+$ 
TrendChart��6�     53      #���  6   $+ >��6>   $��45��6J   $	��150��6V   $��10,0,0,0q�6b   $	��0.1��6�   ��6t   �� *ShiftXCommand+$ 
TrendChart��6�     54      #���  6   $+ >>��6>   $��45��6N   $	��150��6Z   $��10,0,0,0q�6f   $	��0.7��6�   ��6x   �� *ShiftXCommand+$ 
TrendChart��6�   #  VisiWin.Controls.ToggleButton  55        TB_Main#���  6"   $	��150��6D   $��40,0,5,0q�6P   $��45��6b   ,   LocalizableTextOn$, @TrendSystem.Text10��6�   -   LocalizableTextOff$- @TrendSystem.Text11��6�   .   CornerRadius$. 4��6  / d� 	IsChecked/ 6n   �� *
IsOnline+$ DateTimeCurveContainer��6    56      $y�	Collapsed=�6   $��45��63   $	��150��6?   #���  6K   $��	150,0,0,0q�6l   0   LocalizableText$0 @Buttons.Text60��6   $��Center=�6�   $��Right=�6�   57      &   System.Windows.Controls.DataGrid  5:      $��2��6   $��	10,10,5,5q�6$   $��2q�67     FP_BorderBrush#���  6K     DG_Standart#���  6�   $��2��6�   ��6z   �� *CurveInformations+1   Columns1 5;      0  *System.Windows.Controls.DataGridTextColumn  5<      ,  &System.Windows.Controls.DataGridColumn2   Width5  /System.Windows.Controls.DataGridLengthConverter$
2 Auto 6�   3   MinWidth$	3 100Q�6�   4   Header4 6)   6  0VisiWin.Extensions.LocalizedTextBindingExtension  5   LocalizableText$5 @TrendSystem.Text12��1  +System.Windows.Controls.DataGridBoundColumn6   Binding6 6p   �� $ LocalizedArchiveName�6�     5=      $
2 Auto 6�   $	3 150Q�6�   4 6)     $5 @TrendSystem.Text13��6 6p   �� $ LocalizedTrendName�6�     5>      $	2 100 6p    	 TB_Trend7   ElementStyle#7 [	 6}   4 6)     $5 @TrendSystem.Text14��6}     5?      $2 * 6p    
 	TB_Center#7 [
 6�   4 6)     $5 @TrendSystem.Text15��6 6z   �� $ MarkedXValues�6�     5@      $2 * 6p   #7 [
 6�   4 6)     $5 @TrendSystem.Text16��6 6z   �� $ MarkedYValues�6�   5B      5C      � 5E   
     FP_Blue_Gradient#���  6   8 J� Effect8 5F      3  -System.Windows.Media.Effects.DropShadowEffect  5G      9   Color$9 White��6#   :   	Direction$	: 270Q�61   ;   Opacity$	; 0.7Q�6A   .+�5J         VisiWin.Controls.TextBlock  -	   5        <  Name$< header��5J      $��Center=�6X   
�������$
��Bold"�6�   $��48(�6�   $��50,0,0,0q�6�   =   LocalizableText= 6+   �� *TrendData.Header+6�     5K   
   $	��160��6   $��90��6!     	B_Gray_ns#���  6-   $��	0,10,10,0q�6Q   $0 @Buttons.Text56��6d   $	��Top=�6�   $��Right=�6�   ��6�   �� *Back+5M      5O      5P      