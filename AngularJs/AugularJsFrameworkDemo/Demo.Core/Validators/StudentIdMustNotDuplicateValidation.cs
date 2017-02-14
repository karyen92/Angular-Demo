using System.Linq;
using Demo.Core.Database.Model;
using Demo.Framework.Extensions;
using FluentValidation.Validators;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Demo.Core.Validators
{
    public class StudentIdMustNotDuplicateValidation : PropertyValidator
    {
        private readonly IMongoDatabase _db;
        private readonly string _existingId;
        
        public StudentIdMustNotDuplicateValidation(IMongoDatabase db, string existingId = null ) :
            base("Student ID must not be duplicate!")
        {
            _db = db;
            _existingId = existingId;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var collection = _db.GetCollection<StudentIdentity>(typeof(StudentIdentity).CollectionName())
                .AsQueryable();

            bool isExist;

            if (_existingId != null)
            {
                isExist = (from e in collection.AsQueryable()
                    where e.StudentId == (string) context.PropertyValue
                          && e.Id != ObjectId.Parse(_existingId)
                    select e)
                    .Any();
            }
            else
            {
                isExist = (from e in collection.AsQueryable()
                           where e.StudentId == (string)context.PropertyValue 
                           select e)
                    .Any();
            }
            return isExist;
        }
    }
}
