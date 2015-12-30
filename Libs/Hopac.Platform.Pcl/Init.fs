// Copyright (C) by Vesa Karvonen

namespace Hopac.Platform

open System
open System.Threading
open Hopac
open Hopac.Core

module Scheduler =
  let create _
             idleHandler
             _
             numWorkers
//             _
             topLevelHandler =
    let s = Hopac.Scheduler ()
    StaticData.Init ()
    s.TopLevelHandler <- topLevelHandler
    s.IdleHandler <- idleHandler
    s.WaiterStack <- -1
    s.NumActive <- numWorkers
    s.Events <- Array.zeroCreate numWorkers
    let tasks = Array.zeroCreate numWorkers
    for i = 0 to numWorkers - 1 do
      s.Events.[i] <- new WorkerEvent (i)
      let task = Tasks.Task(Action (fun () -> Worker.Run (s, i)), Tasks.TaskCreationOptions.LongRunning)
      tasks.[i] <- task
    for i = 0 to numWorkers - 1 do
      tasks.[i].Start Tasks.TaskScheduler.Default
    s

type [<Class>] Init =
  static member Do () =
    StaticData.createScheduler <- Func<_, _, _, _, _, _>(Scheduler.create)
    StaticData.writeLine <- Action<String>(Diagnostics.Debug.WriteLine)
    StaticData.Init ()
