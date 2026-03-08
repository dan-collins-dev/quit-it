<script>
	import TriggerCard from '$lib/components/TriggerCard.svelte';
	let { data } = $props();
	console.log(data);
</script>

{#each data.triggers as trigger (trigger.id)}
	<TriggerCard trigger={trigger.trigger} />
{/each}

<style>
</style>
