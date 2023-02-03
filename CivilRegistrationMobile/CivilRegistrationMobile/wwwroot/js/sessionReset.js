window.addEventListener("load", reset, false);

async function reset() {
    const response = await fetch("/General/SessionReset");
    const response2 = await fetch("/General/SessionReset");
    console.log("Session reseted");
}