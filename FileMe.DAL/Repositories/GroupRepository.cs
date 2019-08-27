﻿using FileMe.DAL.Classes;
using FileMe.DAL.Filters;
using NHibernate;
using NHibernate.Criterion;

namespace FileMe.DAL.Repositories
{
    public class GroupRepository: Repository<Group, GroupFilter>
    {
        public GroupRepository(ISession session) : base(session) { }

        public Group GetGroup(string name)
        {
            var crit = session.CreateCriteria<Group>().Add(Restrictions.Eq("Name", name));
            var list = crit.List<Group>();
            return list[0];

        }
    }
}
