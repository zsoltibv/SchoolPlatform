   M S B A M L   `   `   `  ����I  ESchoolPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:SchoolPlatform.Views.AdminSchoolPlatform.Views.Admin  5   	   4    .SchoolPlatform.Views.Admin.ManageSubjectsClass   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:SchoolPlatform.Views.Admin     5   	     � Title$  ManageSubjectsClass��5   	   $	��450��6%   $	��800��62   .��5	      � .+�5
   
   �� $
��24px(�6   $��Center=�6    $��0,10,0,0q�6=   $	��Top=�6O   $��44��6g   $	��780��6s   ��5      �� 5      $	��770��6   �� 5      $�Subjects of ��6    �� 5      �6   �� *1/SelectedClass.Specialization.SpecializationName+ �� 5      $�, clasa ��6    �� 5      �6   �� * SelectedClass.YearOfStudy.Year+5      5      �� 5   
   -   5        $��10,69,10,80q�5   �   ��6   �� *ClassSubjects+ �� SelectedItem 69   �� *SelectedClassSubject+��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value$ 35��6/   5       � 	Resources 5      ��%T   '��       �� 5      " ��6   .�5      ��  � ��$
 Left=�6C   5      5       �� View 5      �� 5       .P�5!      �� $��Subject Name��6%    �� Width$	 100��6p    �� DisplayMemberBinding 6;   �� *Subject.SubjectName+6p   �� 5"      $��Professor Name��6%   $	 100��6v    6=   �� *Professor.ProfessorName+6v   5#      5%      �� 5&   
   	 �� Orientation$	 
Horizontal=�6   $
��Left=�6.   $��12,359,0,10q�6I   .+�5(      �� $��Subject:��6   $��Center=�6'   �� 5)      $
��18px(�6   $��5q�6H   
 �� DisplayMemberPath$
 SubjectName��5*      $	��148��6V   ��5)   '   �� *
Subjects+ 5*   -   �� *SelectedSubject+6V   �� 5+      $��
Professor:��6   $��Center=�6)   �� 5,      $
��18px(�6   $��5q�6J   $
 ProfessorName��5-      $	��151��6^   ��5,   '   �� *
Professors+ 5-   3   �� *SelectedProfessor+6^   �� 5.      $��0��6;   $��Add Subject��6P   $	��100��6f   $��5q�6r   ��6   �� *AddSubjectCommand+6r   �� 5/      $��Delete Subject��6>   $	��100��6W   $��5q�6c   ��6   �� *RemoveSubjectCommand+6c   �� 50      $��Edit Subject��6>   $��85��6U   $��5q�6`   ��6   �� *UpdateSubjectCommand+6`   51      52      53      