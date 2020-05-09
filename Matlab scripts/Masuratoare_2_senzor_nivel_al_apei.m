clear all;
close all;
clc;

%A doua masuratoare efectuata asupra senzorului
%de nivel al apei
Dif = 5;
Vcc = [ 4.86  4.82  4.8  4.79  4.79  4.79 4.79  4.8  4.79  4.76  4.76  4.76  4.75  4.74];
avgVcc = mean(Vcc)
Hvas = [ 5 8 12 16 19 23 26 29 32 35 38 41 46];
Hs = Hvas - Dif;
Vout = [1.33  2.09  2.33  2.46  2.54  2.61  2.56  2.59  2.7  2.93  3.08  3.14  3.3];
Vout_posibil = [2.09  2.33  2.46  2.54  2.61  2.56  2.59  2.7  2.93  3.08  3.14  3.3];
figure(1), plot(Hs, Vout, 'o'), hold on
title('A doua masuratoare de etalonare - senzor de nivel al apei'), 
xlabel('Inaltimea coloanei de apa [mm]'), ylabel('Tensiunea de iesire [V]')


Y = polyfit(Hs, Vout, 1)
x = linspace(0, 45);
z = Y(1) * x + Y(2);
plot(x,z)