using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Infrasutructure;
using ShopManagement.Application.Contracts.Comment;
using ShopManagement.Domain.CommentAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class CommentRepository : RepositoryBase<long, Comment>, ICommentRepository
    {
        private readonly ShopContext _contex;

        public CommentRepository(ShopContext contex) : base(contex)
        {
            _contex = contex;
        }

        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {
            var query=_contex.Comments
            .Include(x=>x.Product)
            .Select(x=> new CommentViewModel
            { 
                Id=x.Id,
                Email=x.Email,
                IsCanceled=x.IsCanceled,
                IsConfirmed=x.IsConfirmed,
                Message=x.Message,
                Name=x.Name,
                ProductId=x.ProductId,
                ProductName=x.Product.Name,
                CommentDate=x.CreationDate.ToFarsi()
            });

            if(!string.IsNullOrWhiteSpace(searchModel.Name))
                query=query.Where(x=>x.Name.Contains(searchModel.Name));

            if(!string.IsNullOrWhiteSpace(searchModel.Email))
                query=query.Where(x=>x.Email.Contains(searchModel.Email));

                return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}