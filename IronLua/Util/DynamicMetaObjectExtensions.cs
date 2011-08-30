﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace IronLua.Util
{
    static class DynamicMetaObjectExtensions
    {
        public static BindingRestrictions MergeTypeRestrictions(this DynamicMetaObject dmo1, DynamicMetaObject dmo2)
        {
            return
                dmo1.Restrictions
                    .Merge(dmo2.Restrictions)
                    .Merge(BindingRestrictions.GetTypeRestriction(dmo1.Expression, dmo1.LimitType))
                    .Merge(BindingRestrictions.GetTypeRestriction(dmo2.Expression, dmo2.LimitType));
        }
    }
}