using System;
using System.Collections.Generic;
using System.Text;

public abstract class WorkingUnit
{
    protected WorkingUnit(string id)
    {
        Id = id;
    }

    public string Id { get; protected set; }
}
