﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace IronLua.Runtime
{
    static class RuntimeHelpers
    {
        public static BindingRestrictions MergeTypeRestrictions(DynamicMetaObject dmo1, params DynamicMetaObject[] dmos)
        {
            var newDmos = new DynamicMetaObject[dmos.Length + 1];
            newDmos[0] = dmo1;
            Array.Copy(dmos, 0, newDmos, 1, dmos.Length);
            return MergeTypeRestrictions(newDmos);
        }

        public static BindingRestrictions MergeTypeRestrictions(params DynamicMetaObject[] dmos)
        {
            var restrictions = BindingRestrictions.Combine(dmos);

            foreach (var dmo in dmos)
            {
                if (dmo.HasValue && dmo.Value == null)
                    restrictions = restrictions.Merge(BindingRestrictions.GetInstanceRestriction(dmo.Expression, dmo.Value));
                else
                    restrictions = restrictions.Merge(BindingRestrictions.GetTypeRestriction(dmo.Expression, dmo.LimitType));
            }

            return restrictions;
        }
    }
}