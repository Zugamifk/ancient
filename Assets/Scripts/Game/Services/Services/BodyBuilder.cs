using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBuilder
{
    public BodyModel BuildHuman()
    {
        var body = new BodyModel();
        
        var torso = CreatePart<TorsoModel>("Torso");
        body.Heart = CreatePart<HeartModel>("Hear");
        Connect(body.Heart, torso);
        body.LeftLung = CreatePart<LungModel>("Left Lung");
        Connect(body.LeftLung, torso);
        body.RightLung = CreatePart<LungModel>("Right Lung");
        Connect(body.RightLung, torso);

        body.Head = CreatePart<HeadModel>("Head");
        var leftEye = CreatePart<EyeModel>("Left Eye");
        var rightEye = CreatePart<EyeModel>("Right Eye");
        var nose = CreatePart<NoseModel>("Nose");
        var mouth = CreatePart<MouthModel>("Mouth");
        var hair = CreatePart<HairModel>("Hair");
        body.Brain = CreatePart<BrainModel>("Brain");
        Connect(body.Head, body.Brain);
        Connect(torso, body.Head);

        body.LeftArm = CreatePart<ArmModel>("Left Arm");
        Connect(body.LeftArm, torso);
        var leftHand = CreatePart<HandModel>("Left Hand");
        Connect(body.LeftArm, leftHand);
        body.RightArm = CreatePart<ArmModel>("Right Arm");
        Connect(body.RightArm, torso);
        var rightHand = CreatePart<HandModel>("Right Hand");
        Connect(body.RightArm, rightHand);
        return body;
    }



    public TPart CreatePart<TPart>(string name) where TPart : BodyPartModel, new()
    {
        var part = new TPart();
        part.Name = name;
        if (part is IHasSkin skinned)
        {
            skinned.Skin = new()
            {
                Name = name + " Skin"
            };
        }
        if (part is IHasBone boned)
        {
            boned.Bone = new()
            {
                Name = name + " Bone"
            };
        }
        if (part is IHasBlood blooded)
        {
            blooded.Blood = new()
            {
                Name = name + " Blood"
            };
        }
        if (part is IHasNerves nerved)
        {
            nerved.Nerve = new()
            {
                Name = name + " Nerves"
            };
        }
        if(part is IHasMuscle muscled)
        {
            muscled.Muscle = new()
            {
                Name = name + " Mucles"
            };
        }
        return part;
    }

    public void Connect(BodyPartModel partA, BodyPartModel partB)
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

    public void Disconnect(BodyPartModel partA, BodyPartModel partB)
    {
        partA.Connected.Remove(partB);
        partB.Connected.Remove(partA);

        if ((partA is IHasBone boneA) && (partB is IHasBone boneB))
        {
            Disconnect(boneA.Bone, boneB.Bone);
        }

        if ((partA is IHasBlood bloodA) && (partB is IHasBlood bloodB))
        {
            Disconnect(bloodA.Blood, bloodB.Blood);
        }

        if ((partA is IHasSkin skinA) && (partB is IHasSkin skinB))
        {
            Disconnect(skinA.Skin, skinB.Skin);
        }

        if ((partA is IHasNerves nerveA) && (partB is IHasNerves nerveB))
        {
            Disconnect(nerveA.Nerve, nerveB.Nerve);
        }

        if ((partA is IHasMuscle muscleA) && (partB is IHasMuscle muscleB))
        {
            Disconnect(muscleA.Muscle, muscleB.Muscle);
        }
    }
}

