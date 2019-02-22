using System;
using System.Windows;

namespace CsLaboratory1
{
    internal class DateOfBirth
    {
        public readonly int _age;
        public readonly WesternZodiac _zodiacWestern;
        public readonly ChineseZodiac _zodiacChinese;

        public DateOfBirth(ref DateTime birthDate)
        {
            Birthday(ref birthDate);
            try
            {
                _age = ChooseAge(ref birthDate);
            } catch (ArgumentException argEx)
            {
                MessageBox.Show(argEx.Message);
                birthDate = new DateTime(2000, 2, 12);
                _age = ChooseAge(ref birthDate);
            }
            catch (ArithmeticException arithEx)
            {
                MessageBox.Show(arithEx.Message);
                birthDate = new DateTime(2000, 2, 12);
                _age = ChooseAge(ref birthDate);
            }
            finally
            {
                _zodiacWestern = ChooseSign(ref birthDate);
                _zodiacChinese = CalcChineseZodiac(ref birthDate);
            }
        }

        private void Birthday(ref DateTime dTime)
        {
            if (dTime.Day == DateTime.Today.Day && dTime.Month == DateTime.Today.Month)
                MessageBox.Show("Happy Birthday!!!");
        }

        private int ChooseAge(ref DateTime dTime)
        {
            int age = DateTime.Today.Year - dTime.Year;
            if (dTime > DateTime.Today.AddYears(-age)) age--;
            if (age >= 135) throw new ArgumentException("You can't be so old!");
            if (age < 0) throw new ArithmeticException("You haven't been born yet!");
            return age;
        }

        private WesternZodiac ChooseSign(ref DateTime dTime)
        {
            if ((dTime.Day >= 21 && dTime.Month == 3) || (dTime.Day <= 20 && dTime.Month == 4))
                return WesternZodiac.Ram;
            else if ((dTime.Day >= 21 && dTime.Month == 4) || (dTime.Day <= 20 && dTime.Month == 5))
                return WesternZodiac.Bull;
            else if ((dTime.Day >= 21 && dTime.Month == 5) || (dTime.Day <= 20 && dTime.Month == 6))
                return WesternZodiac.Twins;
            else if ((dTime.Day >= 21 && dTime.Month == 6) || (dTime.Day <= 21 && dTime.Month == 7))
                return WesternZodiac.Crab;
            else if ((dTime.Day >= 22 && dTime.Month == 7) || (dTime.Day <= 21 && dTime.Month == 8))
                return WesternZodiac.Lion;
            else if ((dTime.Day >= 22 && dTime.Month == 8) || (dTime.Day <= 21 && dTime.Month == 9))
                return WesternZodiac.Virgin;
            else if ((dTime.Day >= 22 && dTime.Month == 9) || (dTime.Day <= 21 && dTime.Month == 10))
                return WesternZodiac.Scales;
            else if ((dTime.Day >= 22 && dTime.Month == 10) || (dTime.Day <= 21 && dTime.Month == 11))
                return WesternZodiac.Scorpion;
            else if ((dTime.Day >= 22 && dTime.Month == 11) || (dTime.Day <= 21 && dTime.Month == 12))
                return WesternZodiac.Archer;
            else if ((dTime.Day >= 22 && dTime.Month == 12) || (dTime.Day <= 20 && dTime.Month == 1))
                return WesternZodiac.Goat;
            else if ((dTime.Day >= 22 && dTime.Month == 1) || (dTime.Day <= 20 && dTime.Month == 2))
                return WesternZodiac.WaterBearer;
            else
                return WesternZodiac.Fish;
        }

        private ChineseZodiac CalcChineseZodiac(ref DateTime birthDate)
        {
            return ((ChineseZodiac)(birthDate.Year % 12));
        }
    }
}
