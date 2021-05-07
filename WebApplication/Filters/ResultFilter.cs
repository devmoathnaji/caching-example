using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication.Filters
{
    public class ResultFilter<T> where  T:class
    {
        private ResultModel<T> _resultModel;
        public ResultFilter(ResultModel<T> resultModel)
        {
            _resultModel = resultModel;
        }

        ResultModel<T> ReturnResult()
        {
            var result = new ResultModel<T>();
            result.Result = _resultModel.Result;
            result.Results = _resultModel.Results;
            result.Message = _resultModel.Message;
            result.IsSuccess = _resultModel.IsSuccess;
            result.StatusCode = _resultModel.StatusCode;
            return result;
        }
    }
}