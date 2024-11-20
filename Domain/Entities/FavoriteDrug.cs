﻿namespace Domain.Entities;

public class FavoriteDrug : BaseEntities<FavoriteDrug>
{
    public FavoriteDrug(Guid profileid,Guid drugId, Drug drug,Guid? drugStoreId,DrugStore? drugStore, Profile profile)
    {
        ProfileId = profileid;
        DrugId = drugId;
        DrugStoreId = drugStoreId;
        Profile = profile;
        Drug = drug;
        DrugStore = drugStore;
    }
    
    public Guid ProfileId { get; private set; }
    public Guid DrugId { get; private set; }
    public Guid? DrugStoreId { get; private set; }
    
    // Навигационные свойства
    public Profile Profile { get; private set; }
    public Drug Drug { get; private set; }
    public DrugStore? DrugStore { get; private set; }
}