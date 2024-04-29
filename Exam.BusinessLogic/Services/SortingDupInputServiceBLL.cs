using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.BusinessLogic.Interfaces;
using Exam.Models.Models.SortingDupInputModel;

namespace Exam.BusinessLogic.Services
{
    public class SortingDupInputServiceBLL : ISortingDupInputService
    {
        public SortingDupInputServiceBLL()
        {

        }
        public bool ValidateInputData(SortingDupRequest request)
        {

            if (string.IsNullOrEmpty(request?.P1))
            {
                return false;
            }

            if (request?.P1.Length > 99)
            {
                return false;
            }

           
            return true;

        }

        public List<SortingDupResponse> SortingDupInput(SortingDupRequest request)
        {  

            var isPass = ValidateInputData(request);
            if (isPass == false)
            {
                return new List<SortingDupResponse>();
            }
            
            string numbersString = request.P1;
            //string numbersString = "A,B,1,2,1,AA,3,5,BB,4,2,4,AA,B";
            //string numbersString = "1,2,1,3,5,4,2,4";

            string[] numberArray = numbersString.Split(',');

            Dictionary<string, int> countMap = new Dictionary<string, int>();

            List<string> letters = new List<string>();
            List<string> numbers = new List<string>();

            List<SortingDupResponse> result = new List<SortingDupResponse>();

            foreach (string num in numberArray)
            {
                if (countMap.ContainsKey(num))
                {
                    countMap[num]++;
                }
                else
                {
                    countMap[num] = 1;
                }
            }

            foreach (var kvp in countMap)
            {
                if (kvp.Value > 1)
                {
                    if (int.TryParse(kvp.Key, out int num))
                    {
                        numbers.Add(kvp.Key);
                    }
                    else
                    {
                        letters.Add(kvp.Key);
                    }
                }
            }

            letters = letters.OrderBy(l => l).ToList();
            numbers = numbers.OrderBy(n => n).ToList();

            //letters = letters.OrderByDescending(l => l).ToList();
            //numbers = numbers.OrderByDescending(n => n).ToList();


            foreach (var letter in letters)
            {
                var res = new SortingDupResponse();
                res.Rank = letter;
                result.Add(res);
            }

            foreach (var number in numbers)
            {
                var res = new SortingDupResponse();
                res.Rank = number;

                result.Add(res);
            }

            return result;
        }
    }
}
