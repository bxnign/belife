   M S B A M L   `   `   `  ����K  GBeLifeSegurosWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:BeLifeSegurosWPFBeLifeSegurosWPF  5      H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours 5
      V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5      %    BeLifeSegurosWPF.VentanaCliente   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:BeLifeSegurosWPF     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	      N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5
      JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5        � Title$  VentanaCliente��5      $
��1000��6   $	��700��6+   .��5      � $	��999��6   $	��699��6    J� OpacityMask 5   
   �� 5       �� ImageSource$ Imagenes/Fondo.jpg��6   ��5   
   �� 5      $ Imagenes/Fondo.jpg��6    j� TileMode$
 Tile=�6:    j� Stretch$ UniformToFill=�6J    �� Opacity$	 0.4Q�6b   .+�5   
   �� ���	#FF3B0E4B$
��Left=�6%   $	��667��6@   
���   �$	��Top=�6\   $	��369��6t   �� 5   
   $��Filtrar Busqueda��6   $
��Left=�6-   $	��667��6H   $	��Top=�6U   $	��369��6m   .��5      �� .+�5      �� $��Be��6   $
��Left=�6%   $	��Top=�6@   $��62��6X   $��78��6d   $��Arial)�6o   $��52(�6�    �� Left$	 101��6�   
 �� Top$ 46��6�   
�������6�   �� 5      $
��Life��6   $
��Left=�6'   $	��Top=�6B   $��Arial)�6Z   $��52(�6m   ���	#FFD10AD1$
��Bold"�6�   $	 159��6�   $ 46��6�   $��62��6�   �� 5      $��Buscar Por Rut:��6   $ 27��62   $	 176��6C   
�������6T   �� 5      $��Buscar Por Sexo��6   $ 27��62   $	 226��6C   
�������6T   �� 5      $��Buscar por Estado Civil:��6   $ 27��6;   $	 276��6L   
�������6]   �� 5      -   5         ��Name$ txtBuscarRut��5      $��23��60   $	 196��6<   	 �� TextWrapping$
	 Wrap=�6N   $	 176��6b   $	��140��6s   *  $MahApps.Metro.Controls.TextBoxHelper
   ClearTextButton
 . 6   �� 5      -   5         ��Name$ cboBuscarPorSexo��5      $	 196��65   $	 226��6G   $	��140��6X   6d   �� 5      -   5        $ cboBuscarPorEstadoCivil��5      $	 196��6<   $	 276��6N   $	��140��6_   6k   �� 5       -   5         ��Name$ btnBuscarFiltro��5       $��Buscar por Rut��62   $	 119��6K   $	 386��6]   $	��129��6n   6z   �� 5!      -   5        $ btnBuscarTodos��5!      $��Buscar Todos��61   $	 119��6H   $	 420��6Z   $	��129��6k   6w   5"      5#      &   System.Windows.Controls.DataGrid  5$   
   -   5          Name$ dtDatosCliente��5$      $
��Left=�6+   $	��231��6F   $��446,301,0,0q�6S   $	��Top=�6h   $	��484��6�      Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      -   5        Rut��,  &System.Windows.Controls.DataGridColumn   Header$	 RUT��5&   Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *
RutCliente+6Q     5'      -   5        Nombres��$ Nombres��5'   R    66   �� *	Nombres+6R     5(      -	   5        	Apellidos��$ 	Apellidos��5(   V    68   �� *	Apellidos+6V     5)      -
   5        Sexo��$
 Sexo��5)   X    63   �� *Sexo.Descripcion+6X     5*      -   5        FechaNacimiento��$ Fecha de Nacimiento��5*   b    6>   �� *FechaNacimiento+6b     5+      -   5        EstadoCivil��$ 
Est. Civil��5+   f    6:   �� *EstadoCivil.Descripcion+6f   5-      !  MahApps.Metro.Controls.Tile  5.   
   -   5          Name$ btnIrActualizar��5.      $��446,190,345,422q�61   $
��Auto��6J   $
��Auto��6X   ���	#FF8F038F   Title$ Ir a Actualizar Cliente��6|      TitleFontSize$ 13Q�6�    J� Effect 5/      3  -System.Windows.Media.Effects.DropShadowEffect  50      .��52      �� $$��Imagenes/ActualizarCliente.png��6   $	��128��6<    53        54      56      57        58   
   -   5        $ btnEliminarCliente��58      $��722,190,69,422q�64   $
��Auto��6L   $
��Auto��6Y   ���	#FF8F038F$ Eliminar Cliente��6~   $ 13Q�6�    59        5:      .��5<      �� $"��Imagenes/eliminarCliente.png��6    J� RenderTransformOrigin$ 0.5,0.5&�6;   $��84��6[   $	��100��6f    5=        5>      z�5@      V� 5A      .~�5B      ��  �� ScaleX$ -1Q�6)   �� 5C      �� 5D       �� Angle$ -0.873Q�6*   T� 5E      5F      5H      5I      #  MahApps.Metro.Controls.Flyout  5J   
   -   5          Name$ flyActualizar��5J      $��
0,0,10,429q�61   $	��Top=�6E   ���	#FF9F06AE$��Actualizar Cliente��6t   $ 0.5,0.5&�6�   ��5K      �� 5L       �� Color$ Black��6"   $
 0.93Q�60   .��5N      �� .+�5O      �� $
��Rut:��6   $	 125��6'   $ 36��69   
�������6I   �� 5P      $��Primer Nombre:��6   $	 125��61   $ 86��6C   
�������6S   �� 5Q      $��Primer Apellido:��6   $	 125��63   $	 136��6E   
�������6V   �� 5R      $��Fecha de Nacimiento:��6   $	 425��67   $ 36��6I   
�������6Y   �� 5S      $��Sexo:��6   $	 425��6(   $ 86��6:   
�������6J   �� 5T      $��Estado Civil:��6   $	 425��60   $	 136��6B   
�������6S   �� 5U      -   5        $ txtActualizarRut��5U      $��23��64   $	 241��6@   $
	 Wrap=�6R   $ 36��6f   $	��161��6v   
 . 6�   �� 5V      -   5        $ txtActualizarPrimerNombre��5V      $��23��6=   $	 241��6I   $
	 Wrap=�6[   $ 86��6o   $	��161��6   
 . 6�   �� 5W      -   5        $! txtActualizarPrimerApellido��5W      $��23��6?   $	 241��6K   $
	 Wrap=�6]   $	 136��6q   $	��161��6�   
 . 6�   (	  "System.Windows.Controls.DatePicker	  5X      -   5         	 Name$" dtpActualizarFechaNacimiento��5X      $	 569��6C   $ 36��6U   $	��167��6e   	� 5Y      -   5         	�Name$ optActualizarFemenino��5Y      $��Femenino��6=   $	 569��6P   $ 86��6b   
������� 	� 	GroupName$ ActualizarSexo��6�   	� 5Z      -   5        $ optActualizarMasculino��5Z      $��	Masculino��6>   $	 664��6R   $ 86��6d   
�������$ ActualizarSexo��6�   �� 5[      -   5        $ cboActualizarEstadoCivil��5[      $	 569��6=   $	 136��6O   $	��167��6`   �� 5\      -   5        $ btnActualizar��5\      $��
Actualizar��60   $	 811��6E   $ 36��6W   $	��131��6g   
����������	#FF64088F6�   5]      5^      5_      5`      