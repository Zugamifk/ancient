using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBuilder
{
    public BodyModel BuildHuman()
    {
        var body = new BodyModel();
        
        var torso = CreatePart<TorsoModel>();
        body.Heart = CreatePart<HeartModel>();
        Connect<BodyPartModel>(body.Heart, torso);

        body.Head = CreatePart<HeadModel>();
        var leftEye = CreatePart<EyeModel>();
        var rightEye = CreatePart<EyeModel>();
        var nose = CreatePart<NoseModel>();
        var mouth = CreatePart<MouthModel>();
        var hair = CreatePart<HairModel>();
        body.Brain = CreatePart<BrainModel>();
        Connect<BodyPartModel>(body.Head, body.Brain);
        Connect<BodyPartModel>(torso, body.Head);

        body.LeftArm = CreatePart<ArmModel>();
        Connect<BodyPartModel>(body.LeftArm, torso);
        var leftHand = CreatePart<HandModel>();
        Connect<BodyPartModel>(body.LeftArm, leftHand);
        body.RightArm = CreatePart<ArmModel>();
        Connect<BodyPartModel>(body.RightArm, torso);
        var rightHand = CreatePart<HandModel>();
        Connect<BodyPartModel>(body.RightArm, rightHand);
        return body;
    }



    TPart CreatePart<TPart>() where TPart : BodyPartModel, new()
    {
        var part = new TPart();
        if (part is IHasSkin skinned)
        {
            skinned.Skin = new();
        }
        if (part is IHasBone boned)
        {
            boned.Bone = new();
        }
        if (part is IHasBlood blooded)
        {
            blooded.Blood = new();
        }
        if (part is IHasNerves nerved)
        {
            nerved.Nerve = new();
        }
        if(part is IHasMuscle muscled)
        {
            muscled.Muscle = new();
        }
        return part;
    }

    void Connect<TPart>(TPart partA, TPart partB)
        where TPart : IConnectable<TPart>
    {
        partA.Connected.Add(partB);
        partB.Connected.Add(partA);
        if ((partA is IHasBone boneA) && (partB is IHasBone boneB))
        {
            Connect(boneA.Bone, boneB.Bone);
        }

        if ((partA is IHasBlood bloodA) && (partB is IHasBlood bloodB))
        {
            Connect(bloodA.Blood, bloodB.Blood);
        }

        if ((partA is IHasSkin skinA) && (partB is IHasSkin skinB))
        {
            Connect(skinA.Skin, skinB.Skin);
        }

        if ((partA is IHasNerves nerveA) && (partB is IHasNerves nerveB))
        {
            Connect(nerveA.Nerve, nerveB.Nerve);
        }

        if ((partA is IHasMuscle muscleA) && (partB is IHasMuscle muscleB))
        {
            Connect(muscleA.Muscle, muscleB.Muscle);
        }
    }
}

