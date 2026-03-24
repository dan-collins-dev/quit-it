<script>
	import { onMount } from "svelte";

	let reason = $state(null);

	async function getReason() {
		try {
			const res = await fetch("https://reasons-to-quit-smoking-api.vercel.app/api/reasons");
			const data = await res.json();
			reason = data;
		} catch (error) {
			console.error(error.message);
		}
	}

	onMount(async () => getReason());
</script>

<article>
	<h2>Reason to Not Smoke</h2>
	<p>{reason}</p>
</article>

<style>
	article {
		display: flex;
		flex-direction: column;
		justify-content: space-between;
		background-color: #fff;
		border-radius: 5px;
		box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
		padding: 1rem;
		margin: 0.75rem;
	}

	p,
	h2 {
		color: black;
	}
</style>
