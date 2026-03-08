export async function load({ fetch }) {
	const res = await fetch('http://localhost:7070/api/triggers');
	const triggers = await res.json();
	console.log(triggers);
	return { triggers };
}
